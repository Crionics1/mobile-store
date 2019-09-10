using System.Linq;
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
