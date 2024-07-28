

namespace MovieDatabase.CRUDRepo
{
    public interface IRepo<T>
    {
        void Delete(int id);
        void Update(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
