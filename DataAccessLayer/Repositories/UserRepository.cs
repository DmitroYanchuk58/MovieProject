using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using DataAccessLayer.Validation;
using Microsoft.IdentityModel.Tokens;

namespace DataAccessLayer.Repositories
{
    public class UserRepository:EntityFrameworkRepository<User>
    {
        private readonly DbContext _context;
        private readonly DbSet<User> _dbSet;
        UserValidation validator;
        public UserRepository(DbContext context) : base(context)
        {
            try
            {
                _context = context;
                _dbSet = _context.Set<User>();
                validator = new UserValidation();
            }
            catch
            {
                throw;
            }
        }

        public override void Delete(User entity)
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

        public override IEnumerable<User> GetAll()
        {
            return base.GetAll();
        }

        public override User GetById(int id)
        {
            return base.GetById(id);
        }

        public override void Update(User entity,int id)
        {
            var obj = _dbSet.Find(id);
            if(!entity.Nickname.IsNullOrEmpty())
                obj.Nickname=entity.Nickname;
            if (!entity.Nickname.IsNullOrEmpty())
                obj.Password = entity.Password;
            if (entity.Rates!=null)
                obj.Rates = entity.Rates;
            if (entity.IsDeleted!=null)
                obj.IsDeleted=entity.IsDeleted;
            if(entity.Comments!=null)
                obj.Comments = entity.Comments;
            try
            {
                base.Update(obj, id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public virtual void Create(User entity)
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
