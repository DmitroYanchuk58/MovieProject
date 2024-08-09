using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Contacts;
using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories
{
    public abstract class EntityFrameworkRepository<T> : IRepo<T> where T : Entity
    {
        private readonly DbContext _context;
        private readonly DbSet<T> _dbSet;
        public EntityFrameworkRepository(DbContext context)
        {
            try
            {
                _context = context ?? throw new ArgumentNullException(nameof(context));
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
                _dbSet.Find(entity).IsDeleted=false;
                _context.SaveChanges();
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
                return _dbSet.ToList().Where(obj=>obj.IsDeleted==false);
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

        public virtual void Update(T entity,int id)
        {
            try
            {
                _context.SaveChanges();
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
