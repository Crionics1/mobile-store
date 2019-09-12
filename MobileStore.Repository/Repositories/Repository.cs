using Microsoft.EntityFrameworkCore;
using MobileStore.Domain.Entities;
using MobileStore.Repository.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected MobileDbContext _context;
        protected DbSet<T> _set;

        public Repository(MobileDbContext mobileDbContext)
        {
            _context = mobileDbContext;
            _set = _context.Set<T>();
        }

        public T Create(T t)
        {
            var entity = _set.Add(t);
            return entity.Entity;
        }

        public void Delete(T t)
        {
            _set.Remove(t);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _set;
        }

        public virtual T Get(int id)
        {
            return _set.Find(id);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
