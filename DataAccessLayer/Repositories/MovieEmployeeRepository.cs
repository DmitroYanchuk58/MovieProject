using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using DataAccessLayer.Validation;

namespace DataAccessLayer.Repositories
{
    public class MovieEmployeeRepository:EntityFrameworkRepository<MovieEmployee>
    {
        private readonly DbContext _context;
        private readonly DbSet<MovieEmployee> _dbSet;
        MovieEmployeeValidation validator;
        public MovieEmployeeRepository(DbContext context) : base(context)
        {
            try
            {
                _context = context;
                _dbSet = _context.Set<MovieEmployee>();
                validator = new MovieEmployeeValidation();
            }
            catch
            {
                throw;
            }
        }

        public override void Delete(MovieEmployee entity)
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

        public override IEnumerable<MovieEmployee> GetAll()
        {
            return base.GetAll();
        }

        public override MovieEmployee GetById(int id)
        {
            return base.GetById(id);
        }

        public override void Update(MovieEmployee entity,int id)
        {
            var obj = _dbSet.Find(id);

            var results = validator.Validate(entity);

            if (results.IsValid)
            {
                obj.IdMovie = entity.IdMovie;
                obj.IdEmployee = entity.IdEmployee;
                obj.Movie = entity.Movie;
                obj.Employee = entity.Employee;
                obj.IsDeleted=entity.IsDeleted;
                base.Update(obj, id);
            }
            else
            {
                throw new Exception("The facility failed the inspection");
            }
        }

        public virtual void Create(MovieEmployee entity)
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
