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

        public override void Update(Movie entity)
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
