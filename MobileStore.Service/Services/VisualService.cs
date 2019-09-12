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

        public Visual Create(Visual t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Visual Get(int id)
        {
            return _repository.Get(id);
        }

        public IQueryable<Visual> GetAll()
        {
            return _repository.GetAll();
        }

        public Visual Update(Visual t)
        {
            throw new NotImplementedException();
        }
    }
}
