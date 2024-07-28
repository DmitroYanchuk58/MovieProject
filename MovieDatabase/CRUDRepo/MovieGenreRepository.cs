using Microsoft.EntityFrameworkCore;
using MovieDatabase.Models;
using MovieDatabase.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.CRUDRepo
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

        public override void Update(MovieGenre entity)
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
