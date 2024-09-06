using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using DataAccessLayer.Validation;
using Microsoft.IdentityModel.Tokens;

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
            if(entity.IdMovie!=0)
                obj.IdMovie = entity.IdMovie;
            if(entity.IdUser!=0)
                obj.IdUser=entity.IdUser;
            if(!entity.Text.IsNullOrEmpty())
                obj.Text = entity.Text;
            if(entity.User!=null)
                obj.User = entity.User;
            if(entity.Movie!=null)
                obj.Movie = entity.Movie;
            if(entity.IsDeleted!=null)
                obj.IsDeleted = entity.IsDeleted;
            try
            {
                base.Update(obj, id);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
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
