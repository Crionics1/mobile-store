using MobileStore.Domain.Entities;
using MobileStore.Repository;
using MobileStore.Service.InterFaces;
using System.Linq;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Service.Services
{
    class MobilePhoneService : IMobilePhoneService
    {
        private IRepository<MobilePhone> _repository;
        public MobilePhoneService(IRepository<MobilePhone> repository)
        {
            _repository = repository;
        }

        public async Task<MobilePhone> CreateAsync(MobilePhone mob)
        {
            var mobile = await _repository.CreateAsync(mob);
            return mobile;
        }

        public async Task DeleteAsync(MobilePhone mob)
        {
            await _repository.DeleteAsync(mob);
        }

        public async Task<IEnumerable<MobilePhone>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<MobilePhone> GetAsync(int id)
        {
            var mobile = await _repository.GetAsync(id);
            return mobile;
        }

        public async Task<IEnumerable<MobilePhone>> GetByManufacturer(Manufacturer manufacturer)
        {
            var mobile = from m in (await _repository.GetAll())
                         where m.Manufacturer == manufacturer
                         select m;
            return mobile;
        }

        public async Task<IEnumerable<MobilePhone>> GetByName(string name)
        {
            IEnumerable<MobilePhone> mobile = from m in (await _repository.GetAll())
                                              where m.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                                              orderby m.Name
                                              select m;

            return mobile;
        }

        public async Task<IEnumerable<MobilePhone>> GetByPrice(decimal startPrice = 0, decimal endPrice = decimal.MaxValue, bool descending = false)
        {
            IEnumerable<MobilePhone> mobile = from m in (await _repository.GetAll())
                                              where m.Price >= startPrice && m.Price <= endPrice
                                              orderby m.Price
                                              select m;
            if (descending)
            {
                mobile.OrderByDescending(m => m.Price);
            }

            return mobile;
        }

        public async Task<MobilePhone> UpdateAsync(MobilePhone mob)
        {
            var mobile = await _repository.UpdateAsync(mob);
            return mobile;
        }
    }
}
