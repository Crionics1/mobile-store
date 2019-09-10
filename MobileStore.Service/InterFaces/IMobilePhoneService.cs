using MobileStore.Domain.Entities;
using System.Linq;

namespace MobileStore.Service.InterFaces
{
    public interface IMobilePhoneService : IService<MobilePhone>
    {
        IQueryable<MobilePhone> GetAll(bool includeManufacturer, bool includeVisuals);
        IQueryable<MobilePhone> GetByName(string name);
        IQueryable<MobilePhone> GetByManufacturer(ref IQueryable<MobilePhone> queryable,int manufacturerID);
        IQueryable<MobilePhone> GetByPrice(ref IQueryable<MobilePhone> queryable, decimal? startPrice, decimal? endPrice);
        IQueryable<MobilePhone> Search(string name, decimal? startPrice, decimal? endPrice, int manufacturerID = 0);
    }
}
