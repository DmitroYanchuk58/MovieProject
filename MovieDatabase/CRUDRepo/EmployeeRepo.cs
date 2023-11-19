using MovieDatabase.Models;
using MovieDatabase.Validation;

namespace MovieDatabase.CRUDRepo
{
    public class EmployeeRepo : IRepo<Employee>
    {
        EmployeeValidation valid = new EmployeeValidation();
        Context.MovieDBContext dbContext = new Context.MovieDBContext();

        public bool Create(Employee employee)
        {
            Employee newEmployee = new Employee() { Name = employee.Name, Surname = employee.Surname, MovieEmployees = employee.MovieEmployees, IsDeleted = false };
            if (newEmployee != null)
            {
                var validResult = valid.Validate(newEmployee);
                if (validResult.IsValid)
                {
                    dbContext.Employees.Add(newEmployee);
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            var findEmployee = dbContext.Employees.Find(id);
            if (findEmployee != null)
            {
                var validResult = valid.Validate(findEmployee);
                if (validResult.IsValid)
                {
                    findEmployee.IsDeleted = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public Employee Read(int id)
        {
            var findEmployee = dbContext.Employees.Find(id);
            if (findEmployee != null && !findEmployee.IsDeleted)
            {
                var validResult = valid.Validate(findEmployee);
                if (validResult.IsValid)
                {
                    findEmployee.MovieEmployees = dbContext.MovieEmployees.Where(me => me.IdEmployee == findEmployee.Id).ToList();
                    return findEmployee;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public bool Update(Employee myObject, int id)
        {
            if (myObject != null)
            {
                var validResult = valid.Validate(myObject);
                if (validResult.IsValid)
                {
                    var employee = dbContext.Employees.Find(id);
                    employee = myObject;
                    dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else { return false; }
        }
    }
}
