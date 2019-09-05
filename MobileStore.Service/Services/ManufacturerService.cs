using MobileStore.Domain.Entities;
using MobileStore.Repository;
using MobileStore.Service.InterFaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MobileStore.Service.Services
{
    class ManufacturerService : IManufacturerService
    {
        private IRepository<Manufacturer> _repository;
        private IMobilePhoneService _mobilePhoneService;
        public ManufacturerService(IRepository<Manufacturer> repository,IMobilePhoneService mobilePhoneService)
        {
            _repository = repository;
            _mobilePhoneService = mobilePhoneService;
        }

        public async Task<Manufacturer> CreateAsync(Manufacturer manufacturer)
        {
            var manuf = await _repository.CreateAsync(manufacturer);
            return manuf;
        }

        public async Task<Manufacturer> UpdateAsync(Manufacturer manufacturer)
        {
            var manuf = await _repository.UpdateAsync(manufacturer);
            return manuf;
        }

        public async Task DeleteAsync(Manufacturer manufacturer)
        {
            await _repository.DeleteAsync(manufacturer);
        }

        public async Task<IEnumerable<Manufacturer>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<Manufacturer> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<MobilePhone>> GetMobilePhonesByManufacturer(Manufacturer manufacturer)
        {
            var mobiles = from x in (await _mobilePhoneService.GetAllAsync())
                          where x.ManufacturerID == manufacturer.ID
                          select x;
            return mobiles;
        } 
    }
}
