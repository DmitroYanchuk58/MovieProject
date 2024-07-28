using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.CRUDRepo
{
    public class EntityFrameworkRepository<T> : IRepo<T> where T : class
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
        public void Delete(int id)
        {
            try
            {
                var entity = _dbSet.Find(id);
                _dbSet.Remove(entity);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<T> GetAll()
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

        public T GetById(int id)
        {
            try
            {
                return _dbSet.Find(id);
            }
            catch { throw; }
        }

        public void Update(T entity)
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
    }
}
