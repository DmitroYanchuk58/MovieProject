using MovieDatabase.Models;
using MovieDatabase.Validation;

namespace MovieDatabase.CRUDRepo
{
    public class MovieEmployeeRepo : IRepo<MovieEmployee>
    {
        MovieEmployeeValidation valid = new MovieEmployeeValidation();
        Context.MovieDBContext dbContext = new Context.MovieDBContext();

        public bool Create(MovieEmployee movieEmployee)
        {
            MovieEmployee newMovieEmployee = new MovieEmployee() { Employee = movieEmployee.Employee, IdEmployee = movieEmployee.IdEmployee, IdMovie = movieEmployee.IdMovie, Movie = movieEmployee.Movie, IsDeleted = false };
            if (newMovieEmployee != null)
            {
                var validResult = valid.Validate(newMovieEmployee);
                if (validResult.IsValid)
                {
                    dbContext.MovieEmployees.Add(newMovieEmployee);
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
        public bool Delete(int id)
        {

            var findMovieEmployee = dbContext.MovieEmployees.Find(id);
            if (findMovieEmployee != null)
            {
                var validResult = valid.Validate(findMovieEmployee);
                if (validResult.IsValid)
                {
                    findMovieEmployee.IsDeleted = true;
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

        public MovieEmployee Read(int id)
        {
            var findMovieEmployee = dbContext.MovieEmployees.Find(id);
            if (findMovieEmployee != null && !findMovieEmployee.IsDeleted)
            {
                var validResult = valid.Validate(findMovieEmployee);
                if (validResult.IsValid)
                {
                    findMovieEmployee.Employee = dbContext.Employees.Where(e => e.Id == findMovieEmployee.IdEmployee).First();
                    findMovieEmployee.Movie = dbContext.Movies.Where(m => m.Id == findMovieEmployee.IdMovie).First();
                    return findMovieEmployee;
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

        public bool Update(MovieEmployee myObject, int id)
        {
            if (myObject != null)
            {
                var validResult = valid.Validate(myObject);
                if (validResult.IsValid)
                {
                    var movieEmployee = dbContext.MovieEmployees.Find(id);
                    movieEmployee = myObject;
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
    }
}
