using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using DataAccessLayer.Validation;

namespace DataAccessLayer.Repositories
{
    public class MovieGenreRepository:EntityFrameworkRepository<MovieGenre>
    {
        private readonly DbContext _context;
        private readonly DbSet<MovieGenre> _dbSet;
        MovieGenreValidation validator;
        public MovieGenreRepository(DbContext context) : base(context)
        {
            try
            {
                _context = context;
                _dbSet = _context.Set<MovieGenre>();
                validator = new MovieGenreValidation();
            }
            catch
            {
                throw;
            }
        }

        public override void Delete(MovieGenre entity)
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

        public override IEnumerable<MovieGenre> GetAll()
        {
            return base.GetAll();
        }

        public override MovieGenre GetById(int id)
        {
            return base.GetById(id);
        }

        public override void Update(MovieGenre entity,int id)
        {
            var obj = _dbSet.Find(id);

            var results = validator.Validate(entity);

            if (results.IsValid)
            {
                obj.IdMovie = entity.IdMovie;
                obj.IdGenre = entity.IdGenre;
                obj.IsDeleted=entity.IsDeleted;
                obj.Movie=entity.Movie;
                obj.Genre=entity.Genre;
                base.Update(obj, id);
            }
            else
            {
                throw new Exception("The facility failed the inspection");
            }
        }

        public virtual void Create(MovieGenre entity)
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
