using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using DataAccessLayer.Validation;

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

        public override void Update(User entity)
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
