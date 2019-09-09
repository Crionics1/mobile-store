using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileStore.Repository.Interfaces
{
    public interface IMobilePhoneRepository : IRepository<MobilePhone>
    {
        IQueryable<MobilePhone> GetAll(bool includeManufacturer, bool includeVisuals);
    }
}
