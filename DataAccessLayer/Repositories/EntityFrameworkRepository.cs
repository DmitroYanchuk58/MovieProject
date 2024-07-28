using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Contacts;

namespace DataAccessLayer.Repositories
{
    public abstract class EntityFrameworkRepository<T> : IRepo<T> where T : class
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        public EntityFrameworkRepository(DbContext context)
        {
            try
            {
                _context = context;
                _dbSet = _context.Set<T>();
            }
            catch
            {
                throw;
            }
        }
        public virtual void Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
            }
            catch
            {
                throw;
            }
        }

        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return _dbSet.ToList();
            }
            catch
            {
                throw;
            }
        }

        public virtual T GetById(int id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch { throw; }
        }

        public virtual void Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
            }
            catch
            {
                throw;
            }
        }

        public virtual void Create(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                _context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
