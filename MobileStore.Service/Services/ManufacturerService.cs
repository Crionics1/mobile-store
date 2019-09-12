using MobileStore.Domain.Entities;
using MobileStore.Service.InterFaces;
using System.Threading.Tasks;
using System.Linq;
using MobileStore.Repository.Interfaces;
using MobileStore.Service.Exceptions;

namespace MobileStore.Service.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private IRepository<Manufacturer> _repository;
        private IMobilePhoneService _mobilePhoneService;
        public ManufacturerService(IRepository<Manufacturer> repository, IMobilePhoneService mobilePhoneService)
        {
            _repository = repository;
            _mobilePhoneService = mobilePhoneService;
        }

        public Manufacturer Create(Manufacturer manufacturer)
        {
            var manuf = _repository.Create(manufacturer);
            if (_repository.SaveChanges())
            {
                return manuf;
            }
            throw new BadRequestException("Failed to craete Manufacturer");
        }

        public Manufacturer Update(Manufacturer manufacturer)
        {
            var manuf = _repository.Get(manufacturer.ID);
            if (manuf == null)
            {
                throw new BadRequestException("Failed to find Manufacturer to update!");
            }

            manuf = manufacturer;
            if (_repository.SaveChanges())
            {
                return manuf;
            }
            throw new BadRequestException("No changes to update");
        }

        public void Delete(int id)
        {
            var manufacturer = _repository.Get(id);
            if (manufacturer == null)
            {
                throw new BadRequestException("Failed to find Manufacturer to delete!");
            }

            _repository.Delete(manufacturer);
            _repository.SaveChanges();
        }

        public IQueryable<Manufacturer> GetAll()
        {
            return _repository.GetAll();
        }

        public Manufacturer Get(int id)
        {
            return _repository.Get(id);
        }

        public IQueryable<MobilePhone> GetMobilePhonesByManufacturer(int manufacturerID)
        {
            var mobiles = from x in _mobilePhoneService.GetAll()
                          where x.ManufacturerID == manufacturerID
                          select x;
            return mobiles;
        }
    }
}
