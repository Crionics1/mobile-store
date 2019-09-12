using Microsoft.EntityFrameworkCore;
using MobileStore.Domain.Entities;
using MobileStore.Repository.Interfaces;
using System.Linq;
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

        public override MobilePhone Get(int id)
        {
            return _set.Include(s => s.Manufacturer).Include(s => s.Visuals).FirstOrDefault(m => m.ID == id);
        }
    }
}
