using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Service.InterFaces
{
    interface IManufacturerService : IService<Manufacturer>
    {
        Task<IEnumerable<MobilePhone>> GetMobilePhonesByManufacturer(Manufacturer manufacturer);
    }
}
