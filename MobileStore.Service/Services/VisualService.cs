using MobileStore.Domain.Entities;
using MobileStore.Repository.Interfaces;
using MobileStore.Service.InterFaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Service.Services
{
    public class VisualService : IService<Visual>
    {
        private IRepository<Visual> _repository;
        public VisualService(IRepository<Visual> repository)
        {
            _repository = repository;
        }
        public async Task<Visual> CreateAsync(Visual t)
        {
            return await _repository.CreateAsync(t);
        }

        public Task DeleteAsync(Visual t)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Visual> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<Visual> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public Task<Visual> UpdateAsync(Visual t)
        {
            throw new NotImplementedException();
        }
    }
}
