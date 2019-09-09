using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MobileStore.Domain.Entities;
using MobileStore.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Repository.Repositories
{
    public class MobilePhoneRepository : Repository<MobilePhone>, IMobilePhoneRepository
    {
        public MobilePhoneRepository(MobileDbContext context) : base(context) { }

        public IQueryable<MobilePhone> GetAll(bool includeManufacturer, bool includeVisuals)
        {
            IQueryable<MobilePhone> query;
            if (includeManufacturer && includeVisuals)
            {
                query = _set.Include(m => m.Manufacturer).Include(m => m.Visuals);
            }
            else if (includeManufacturer)
            {
                query = _set.Include(m => m.Manufacturer);
            }
            else if(includeVisuals)
            {
                query = _set.Include(m => m.Visuals);
            }
            else
            {
                return GetAll();
            }

            return query;
        }

        public new async Task<MobilePhone> GetAsync(int id)
        {
            return await _set.Include(s => s.Manufacturer).Include(s => s.Visuals).SingleOrDefaultAsync(m => m.ID == id);
        }
    }
}
