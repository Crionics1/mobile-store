using MobileStore.Domain.Entities;
using MobileStore.Service.InterFaces;
using System.Threading.Tasks;
using System.Linq;
using MobileStore.Repository.Interfaces;

namespace MobileStore.Service.Services
{
    public class ManufacturerService : IManufacturerService
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

        public IQueryable<Manufacturer> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<Manufacturer> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
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
