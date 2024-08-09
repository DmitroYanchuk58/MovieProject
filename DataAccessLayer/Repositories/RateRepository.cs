using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using DataAccessLayer.Validation;

namespace DataAccessLayer.Repositories
{
    public class RateRepository:EntityFrameworkRepository<Rate>
    {
        private readonly DbContext _context;
        private readonly DbSet<Rate> _dbSet;
        RateValidation validator;
        public RateRepository(DbContext context) : base(context)
        {
            try
            {
                _context = context;
                _dbSet = _context.Set<Rate>();
                validator = new RateValidation();
            }
            catch
            {
                throw;
            }
        }

        public override void Delete(Rate entity)
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

        public override IEnumerable<Rate> GetAll()
        {
            return base.GetAll();
        }

        public override Rate GetById(int id)
        {
            return base.GetById(id);
        }

        public List<Rate> GetByIdToList(int id)
        {
            try
            {
                return _dbSet.Where(rate=>rate.Id == id).ToList();
            }
            catch { throw; }
        }

        public override void Update(Rate entity, int id)
        {
            var obj = _dbSet.Find(id);

            var results = validator.Validate(entity);

            if (results.IsValid)
            {
                obj.IdMovie = entity.IdMovie;
                obj.IdUser = entity.IdUser;
                obj.Evaluation = entity.Evaluation;
                obj.Movie = entity.Movie;
                obj.User = entity.User;
                obj.IsDeleted = entity.IsDeleted;
                base.Update(obj, id);
            }
            else
            {
                throw new Exception("The facility failed the inspection");
            }
        }

        public virtual void Create(Rate entity)
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
