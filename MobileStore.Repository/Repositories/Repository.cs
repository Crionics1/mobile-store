using Microsoft.EntityFrameworkCore;
using MobileStore.Domain.Entities;
using MobileStore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<T> CreateAsync(T t)
        {
            var entity = _set.Add(t);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task DeleteAsync(T t)
        {
            _set.Remove(t);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll()
        {
            return _set;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _set.SingleOrDefaultAsync(t => t.ID == id);
        }

        public async Task<T> UpdateAsync(T t)
        {
            var entity = _set.Update(t);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }
    }
}
