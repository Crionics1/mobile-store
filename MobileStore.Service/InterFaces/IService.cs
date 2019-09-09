﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Service.InterFaces
{
    public interface IService<T>
    {
        Task<T> CreateAsync(T t);
        Task<T> UpdateAsync(T t);
        Task DeleteAsync(T t);
        Task<T> GetAsync(int id);
        IQueryable<T> GetAll();
    }
}
