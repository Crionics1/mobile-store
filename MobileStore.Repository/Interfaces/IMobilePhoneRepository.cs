using MobileStore.Domain.Entities;
using System.Linq;

namespace MobileStore.Repository.Interfaces
{
    public interface IMobilePhoneRepository : IRepository<MobilePhone>
    {
        IQueryable<MobilePhone> GetAll(bool includeManufacturer, bool includeVisuals);
    }
}
