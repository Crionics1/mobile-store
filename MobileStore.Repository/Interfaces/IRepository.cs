using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Repository.Interfaces
{
    public interface IRepository<T>
    {
        T Create(T t);
        void Delete(T t);
        T Get(int id);
        IQueryable<T> GetAll();
        bool SaveChanges();
    }
}
