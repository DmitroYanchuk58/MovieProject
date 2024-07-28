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

        public override void Update(Rate entity)
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
