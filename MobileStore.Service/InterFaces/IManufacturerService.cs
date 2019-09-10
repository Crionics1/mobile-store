using MobileStore.Domain.Entities;
using System.Linq;

namespace MobileStore.Service.InterFaces
{
    public interface IManufacturerService : IService<Manufacturer>
    {
        IQueryable<MobilePhone> GetMobilePhonesByManufacturer(int manufacturerID);
    }
}
