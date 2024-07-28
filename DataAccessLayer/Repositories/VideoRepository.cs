using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using DataAccessLayer.Validation;

namespace DataAccessLayer.Repositories
{
    public class VideoRepository:EntityFrameworkRepository<Video>
    {
        private readonly DbContext _context;
        private readonly DbSet<Video> _dbSet;
        VideoValidation validator;
        public VideoRepository(DbContext context) : base(context)
        {
            try
            {
                _context = context;
                _dbSet = _context.Set<Video>();
                validator = new VideoValidation();
            }
            catch
            {
                throw;
            }
        }

        public override void Delete(Video entity)
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

        public override IEnumerable<Video> GetAll()
        {
            return base.GetAll();
        }

        public override Video GetById(int id)
        {
            return base.GetById(id);
        }

        public override void Update(Video entity)
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

        public virtual void Create(Video entity)
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
