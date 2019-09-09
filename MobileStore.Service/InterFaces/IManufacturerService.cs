using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Service.InterFaces
{
    public interface IManufacturerService : IService<Manufacturer>
    {
        IQueryable<MobilePhone> GetMobilePhonesByManufacturer(int manufacturerID);
    }
}
