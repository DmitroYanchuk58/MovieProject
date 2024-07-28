using Microsoft.EntityFrameworkCore;
using MovieDatabase.CRUDRepo;
using MovieDatabase.Models;
using MovieDatabase.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Controllers
{
    public class CommentRepository : EntityFrameworkRepository<Comment>
    {
        private readonly DbContext _context;
        private readonly DbSet<Comment> _dbSet;
        CommentValidation validator;
        public CommentRepository(DbContext context) : base(context)
        {
            try
            {
                _context = context;
                _dbSet = _context.Set<Comment>();
                validator = new CommentValidation();
            }
            catch
            {
                throw;
            }
        }

        public override void Delete(Comment entity)
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

        public override IEnumerable<Comment> GetAll()
        {
            return base.GetAll();
        }

        public override Comment GetById(int id)
        {
           return base.GetById(id);
        }

        public override void Update(Comment entity)
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

        public virtual void Create(Comment entity)
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
