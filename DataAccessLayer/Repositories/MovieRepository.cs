using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using DataAccessLayer.Validation;

namespace DataAccessLayer.Repositories
{
    public class MovieRepository:EntityFrameworkRepository<Movie>
    {
        private readonly DbContext _context;
        private readonly DbSet<Movie> _dbSet;
        MovieValidation validator;
        public MovieRepository(DbContext context) : base(context)
        {
            try
            {
                _context = context;
                _dbSet = _context.Set<Movie>();
                validator = new MovieValidation();
            }
            catch
            {
                throw;
            }
        }

        public override void Delete(Movie entity)
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

        public override IEnumerable<Movie> GetAll()
        {
            return base.GetAll();
        }

        public override Movie GetById(int id)
        {
            return base.GetById(id);
        }

        public override void Update(Movie entity,int id)
        {
            var movie= _dbSet.Find(id);

            var results = validator.Validate(entity);

            if (results.IsValid)
            {
                movie.Name=entity.Name;
                movie.Description=entity.Description;
                movie.MovieGenres=entity.MovieGenres;
                movie.Comments=entity.Comments;
                movie.MovieEmployees=entity.MovieEmployees;
                movie.IsDeleted=entity.IsDeleted;
                movie.Rates=entity.Rates;
                movie.Videos=entity.Videos;
                base.Update(movie,id);
            }
            else
            {
                throw new Exception("The facility failed the inspection");
            }
        }

        public virtual void Create(Movie entity)
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
