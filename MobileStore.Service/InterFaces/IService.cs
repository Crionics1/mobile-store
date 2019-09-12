using System.Linq;
using System.Threading.Tasks;

namespace MobileStore.Service.InterFaces
{
    public interface IService<T>
    {
        T Create(T t);
        T Update(T t);
        void Delete(int id);
        T Get(int id);
        IQueryable<T> GetAll();
    }
}
