using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using DataAccessLayer.Validation;

namespace DataAccessLayer.Repositories
{
    public class GenreRepository:EntityFrameworkRepository<Genre>
    {
        private readonly DbContext _context;
        private readonly DbSet<Genre> _dbSet;
        GenreValidation validator;
        public GenreRepository(DbContext context) : base(context)
        {
            try
            {
                _context = context;
                _dbSet = _context.Set<Genre>();
                validator = new GenreValidation();
            }
            catch
            {
                throw;
            }
        }

        public override void Delete(Genre entity)
        {
            var results = validator.Validate(entity);
            if (results.IsValid)
            {
                base.Delete(entity);
            }
            else
            {
                throw new Exception("The facility failed the inspection");
            }
        }

        public override IEnumerable<Genre> GetAll()
        {
            return base.GetAll();
        }

        public override Genre GetById(int id)
        {
            return base.GetById(id);
        }

        public override void Update(Genre entity)
        {
            var results = validator.Validate(entity);
            if (results.IsValid)
            {
                base.Update(entity);
            }
            else
            {
                throw new Exception("The facility failed the inspection");
            }
        }

        public virtual void Create(Genre entity)
        {
            var results = validator.Validate(entity);
            if (results.IsValid)
            {
                base.Create(entity);
            }
            else
            {
                throw new Exception("The facility failed the inspection");
            }
        }
    }
}
