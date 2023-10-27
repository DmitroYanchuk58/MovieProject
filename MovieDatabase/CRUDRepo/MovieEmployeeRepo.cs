using MovieDatabase.Models;
using MovieDatabase.Validation;

namespace MovieDatabase.CRUDRepo
{
    //public class MovieEmployeeRepo:IRepo<MovieEmployee>
    //{
    //    ModelValidation validation = new ModelValidation();
    //    Context.MovieDBContext dbContext = new Context.MovieDBContext();

    //    public bool Create(MovieEmployee movieEmployee)
    //    {
    //        MovieEmployee newMovieEmployee = new MovieEmployee() { Id = dbContext.Genres.Any() ? dbContext.Genres.Max(x => x.Id) + 1 : 0, Employee=movieEmployee.Employee,IdEmployee=movieEmployee.IdEmployee,IdMovie=movieEmployee.IdMovie,Movie=movieEmployee.Movie};
    //        if (validation.ValidationMovieEmployee(newMovieEmployee))
    //        {
    //            dbContext.MovieEmployees.Add(newMovieEmployee);
    //            dbContext.SaveChanges();
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //        return true;
    //    }
    //    public bool Delete(int id)
    //    {
    //        var findMovieEmployee = dbContext.MovieEmployees.Find(id);
    //        if (validation.ValidationMovieEmployee(findMovieEmployee))
    //        {
    //            dbContext.Remove(findMovieEmployee);
    //            dbContext.SaveChanges();
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }

    //    public MovieEmployee Read(int id)
    //    {
    //        var findMovieEmployee = dbContext.MovieEmployees.Find(id);
    //        if (validation.ValidationMovieEmployee(findMovieEmployee))
    //        {
    //            return findMovieEmployee;
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }

    //    public bool Update(MovieEmployee myObject, int id)
    //    {
    //        if (validation.ValidationMovieEmployee(myObject))
    //        {
    //            var movieEmployee = dbContext.MovieEmployees.Find(id);
    //            movieEmployee = myObject;
    //            dbContext.SaveChanges();
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //}
}
