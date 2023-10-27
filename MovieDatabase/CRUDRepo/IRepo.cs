

namespace MovieDatabase.CRUDRepo
{
    public interface IRepo<T>
    {
        bool Delete(int id);
        T Read(int id);
        bool Update(T myObject,int id);
    }
}
