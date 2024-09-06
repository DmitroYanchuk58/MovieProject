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

            if(entity.IdMovie!=0)
                obj.IdMovie = entity.IdMovie;
            if(entity.IdUser!=0)
                obj.IdUser = entity.IdUser;
            if(entity.Evaluation!=0&&entity.Evaluation<100&&entity.Evaluation>0)
                obj.Evaluation = entity.Evaluation;
            if(entity.Movie!=null)
                obj.Movie = entity.Movie;
            if(entity.User!=null)
                obj.User = entity.User;
            if(entity.IsDeleted!=null)
                obj.IsDeleted = entity.IsDeleted;

            try
            {
                base.Update(obj, id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual void Create(Rate entity)
        {
            var results = validator.Validate(entity);
            if (results.IsValid)
            {
                if (RateExists(entity))
                {
                   throw new Exception("Rate already exists");
                }
                base.Create(entity);
            }
            else
            {
                throw new Exception("The facility failed the inspection");
            }
        }

        private bool RateExists(Rate entity)
        {
            return _dbSet.Any(rate => rate.IdMovie == entity.IdMovie && rate.IdUser == entity.IdUser);
        }
    }
}
