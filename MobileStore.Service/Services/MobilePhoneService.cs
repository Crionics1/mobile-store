using MobileStore.Domain.Entities;
using MobileStore.Service.InterFaces;
using System.Linq;
using System.Threading.Tasks;
using MobileStore.Repository.Interfaces;
using MobileStore.Service.Exceptions;

namespace MobileStore.Service.Services
{
    public class MobilePhoneService : IMobilePhoneService
    {
        private IMobilePhoneRepository _repository;
        public MobilePhoneService(IMobilePhoneRepository repository)
        {
            _repository = repository;
        }

        public MobilePhone Create(MobilePhone mob)
        {
            var mobile = _repository.Create(mob);
            if (_repository.SaveChanges())
            {
                return mobile;
            }
            throw new BadRequestException("Failed to create mobile phone!");
        }

        public void Delete(int id)
        {
            var mobile = _repository.Get(id);
            if (mobile == null)
            {
                throw new BadRequestException("Failed to find mobile phone to delete!");
            }

            _repository.Delete(mobile);
            _repository.SaveChanges();
        }

        public IQueryable<MobilePhone> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<MobilePhone> GetAll(bool includeManufacturer, bool includeVisuals)
        {
            return _repository.GetAll(includeManufacturer, includeVisuals);
        }

        public MobilePhone Get(int id)
        {
            var mobile = _repository.Get(id);
            return mobile;
        }

        public IQueryable<MobilePhone> GetByManufacturer(ref IQueryable<MobilePhone> queryable, int manufacturerID)
        {
            queryable = from m in queryable
                        where m.Manufacturer.ID == manufacturerID
                        select m;
            return queryable;
        }

        public IQueryable<MobilePhone> GetByName(string name)
        {
            var mobiles = from m in _repository.GetAll(true, true)
                          where m.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                          orderby m.Name
                          select m;

            return mobiles;
        }

        public IQueryable<MobilePhone> GetByPrice(ref IQueryable<MobilePhone> queryable, decimal? startPrice, decimal? endPrice)
        {
            if (startPrice == null)
            {
                startPrice = 0;
            }
            if (endPrice == null)
            {
                endPrice = decimal.MaxValue;
            }
            queryable = from m in queryable
                        where m.Price >= startPrice && m.Price <= endPrice
                        orderby m.Price
                        select m;
            return queryable;
        }

        public MobilePhone Update(MobilePhone mob)
        {
            var mobile = _repository.Get(mob.ID);
            if (mobile == null)
            {
                throw new BadRequestException("Failed to find mobile to update");
            }

            mobile = mob;
            if (_repository.SaveChanges())
            {
                return mobile;
            }

            throw new BadRequestException("No changes to update");
        }

        public IQueryable<MobilePhone> Search(string name, decimal? startPrice, decimal? endPrice, int manufacturerID = 0)
        {
            var items = GetByName(name);
            if (startPrice != null || endPrice != null)
            {
                GetByPrice(ref items, startPrice, endPrice);
            }
            if (manufacturerID != 0)
            {
                GetByManufacturer(ref items, manufacturerID);
            }
            return items;
        }
    }
}