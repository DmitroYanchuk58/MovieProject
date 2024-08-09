using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using DataAccessLayer.Validation;

namespace DataAccessLayer.Repositories
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

        public override void Update(Comment entity, int id)
        {
            var obj = _dbSet.Find(id);

            var results = validator.Validate(entity);

            if (results.IsValid)
            {
                obj.IdMovie = entity.IdMovie;
                obj.IdUser=entity.IdUser;
                obj.Text = entity.Text;
                obj.User = entity.User;
                obj.Movie = entity.Movie;
                obj.IsDeleted = entity.IsDeleted;
                base.Update(obj, id);
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
