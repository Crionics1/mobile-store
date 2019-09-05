using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MobileStore.Service.InterFaces
{
    interface IService<T>
    {
        Task<T> CreateAsync(T t);
        Task<T> UpdateAsync(T t);
        Task DeleteAsync(T t);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
