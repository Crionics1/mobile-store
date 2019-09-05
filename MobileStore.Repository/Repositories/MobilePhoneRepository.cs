using Microsoft.EntityFrameworkCore;
using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Repository.Repositories
{
    public class MobilePhoneRepository : Repository<MobilePhone>
    {
        public MobilePhoneRepository(MobileDbContext context) : base(context) { }

        public new async Task<IEnumerable<MobilePhone>> GetAllAsync()
        {
            return await _set.Include(s => s.Manufacturer).ToListAsync();
        }

        public new async Task<MobilePhone> GetAsync(int id)
        {
            return await _set.Include(s => s.Manufacturer).SingleOrDefaultAsync(m => m.ID == id);
        }
    }
}
