using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Service.InterFaces
{
    interface IMobilePhoneService : IService<MobilePhone>
    {
        Task<IEnumerable<MobilePhone>> GetByName(string name);
        Task<IEnumerable<MobilePhone>> GetByManufacturer(Manufacturer manufacturer);
        Task<IEnumerable<MobilePhone>> GetByPrice(decimal startPrice, decimal endPrice, bool descending);
    }
}
