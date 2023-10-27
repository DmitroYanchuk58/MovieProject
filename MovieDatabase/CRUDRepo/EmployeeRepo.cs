using MovieDatabase.Models;
using MovieDatabase.Validation;

namespace MovieDatabase.CRUDRepo
{
    public class EmployeeRepo:IRepo<Employee>
    {
        //ModelValidation validation = new ModelValidation();
        Context.MovieDBContext dbContext = new Context.MovieDBContext();

        public bool Create(Employee employee)
        {
            //Employee newEmployee = new Employee() { Id = dbContext.Employees.Any() ? dbContext.Employees.Max(x => x.Id) + 1 : 0, MovieEmployees=employee.MovieEmployees};
            //if (validation.ValidationEmployee(newEmployee))
            //{
            //    dbContext.Employees.Add(newEmployee);
            //    dbContext.SaveChanges();
            //}
            //else
            //{
            //    return false;
            //}
            return true;
        }
        public bool Delete(int id)
        {
            //var findEmployee = dbContext.Employees.Find(id);
            //if (validation.ValidationEmployee(findEmployee))
            //{
            //    dbContext.Remove(findEmployee);
            //    dbContext.SaveChanges();
            //    return true;
            //}
            //else
            //{
                return false;
            //}
        }

        public Employee Read(int id)
        {
            //var findEmployee = dbContext.Employees.Find(id);
            //if (validation.ValidationEmployee(findEmployee))
            //{
            //    return findEmployee;
            //}
            //else
            //{
                return null;
            //}
        }

        public bool Update(Employee myObject, int id)
        {
        //    if (validation.ValidationEmployee(myObject))
        //    {
        //        var employee = dbContext.Employees.Find(id);
        //        employee = myObject;
        //        dbContext.SaveChanges();
        //        return true;
        //    }
        //    else
        //    {
                return false;
            //}
        }
    }
}
