using MobileStore.Domain.Entities;
using MobileStore.Repository;
using MobileStore.Service.InterFaces;
using System.Linq;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MobileStore.Repository.Interfaces;
using MobileStore.Repository.Repositories;

namespace MobileStore.Service.Services
{
    public class MobilePhoneService : IMobilePhoneService
    {
        private IMobilePhoneRepository _repository;
        public MobilePhoneService(IMobilePhoneRepository repository)
        {
            _repository = repository;
        }

        public async Task<MobilePhone> CreateAsync(MobilePhone mob)
        {
            var mobile = await _repository.CreateAsync(mob);
            return mobile;
        }

        public async Task DeleteAsync(MobilePhone mob)
        {
            await _repository.DeleteAsync(mob);
        }

        public IQueryable<MobilePhone> GetAll()
        {
            return _repository.GetAll();
        }

        public IQueryable<MobilePhone> GetAll(bool includeManufacturer, bool includeVisuals)
        {
            return _repository.GetAll(includeManufacturer, includeVisuals);
        }

        public async Task<MobilePhone> GetAsync(int id)
        {
            var mobile = await _repository.GetAsync(id);
            return mobile;
        }

        public IQueryable<MobilePhone> GetByManufacturer(ref IQueryable<MobilePhone> queryable, int manufacturerID)
        {
            queryable = from m in queryable
                        where m.Manufacturer.ID == manufacturerID
                        select m;
            return queryable;
        }

        public IQueryable<MobilePhone> GetByName(string name)
        {
            var mobiles = from m in _repository.GetAll(true, true)
                          where m.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                          orderby m.Name
                          select m;

            return mobiles;
        }

        public IQueryable<MobilePhone> GetByPrice(ref IQueryable<MobilePhone> queryable, decimal? startPrice, decimal? endPrice)
        {
            if (startPrice == null)
            {
                startPrice = 0;
            }
            if (endPrice == null)
            {
                endPrice = decimal.MaxValue;
            }
            queryable = from m in queryable
                        where m.Price >= startPrice && m.Price <= endPrice
                        orderby m.Price
                        select m;
            return queryable;
        }

        public async Task<MobilePhone> UpdateAsync(MobilePhone mob)
        {
            var mobile = await _repository.UpdateAsync(mob);
            return mobile;
        }

        public IQueryable<MobilePhone> Search(string name, decimal? startPrice, decimal? endPrice, int manufacturerID = 0)
        {
            var items = GetByName(name);
            if (startPrice != null || endPrice != null)
            {
                GetByPrice(ref items, startPrice, endPrice);
            }
            if (manufacturerID != 0)
            {
                GetByManufacturer(ref items, manufacturerID);
            }
            return items;
        }
    }
}