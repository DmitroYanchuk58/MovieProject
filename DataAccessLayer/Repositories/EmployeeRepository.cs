using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Models;
using DataAccessLayer.Validation;

namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : EntityFrameworkRepository<Employee>
    {
        private readonly DbContext _context;
        private readonly DbSet<Employee> _dbSet;
        EmployeeValidation validator;
        public EmployeeRepository(DbContext context) : base(context)
        {
            try
            {
                _context = context;
                _dbSet = _context.Set<Employee>();
                validator = new EmployeeValidation();
            }
            catch
            {
                throw;
            }
        }

        public override void Delete(Employee entity)
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

        public override IEnumerable<Employee> GetAll()
        {
            return base.GetAll();
        }

        public override Employee GetById(int id)
        {
            return base.GetById(id);
        }

        public override void Update(Employee entity, int id)
        {
            var obj = _dbSet.Find(id);

            var results = validator.Validate(entity);

            if (results.IsValid)
            {
                obj.Name=entity.Name;
                obj.Surname=entity.Surname;
                obj.IsDeleted=entity.IsDeleted;
                obj.MovieEmployees=entity.MovieEmployees;
                base.Update(obj, id);
            }
            else
            {
                throw new Exception("The facility failed the inspection");
            }
        }

        public virtual void Create(Employee entity)
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
