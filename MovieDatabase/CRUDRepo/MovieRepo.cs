using MovieDatabase.Models;
using MovieDatabase.Validation;

namespace MovieDatabase.CRUDRepo
{
    public class MovieRepo : IRepo<Movie>
    {
        MovieValidation valid=new MovieValidation();
        Context.MovieDBContext dbContext = new Context.MovieDBContext();

        public bool Create(Movie movie)
        {
            Movie newMovie = new Movie() { Name=movie.Name,Description=movie.Description };
            if (newMovie != null)
            {
                var validResult = valid.Validate(newMovie);
                if (validResult.IsValid)
                {
                    dbContext.Movies.Add(newMovie);
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
            var findMovie = dbContext.Movies.Find(id);
            if (findMovie != null)
            {
                var validResult = valid.Validate(findMovie);
                if (validResult.IsValid)
                {
                    dbContext.Remove(findMovie);
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

        public Movie Read(int id)
        {
            var findMovie = dbContext.Movies.Find(id);
            var validResult = valid.Validate(findMovie);
            if (validResult.IsValid)
            {
                return findMovie;
            }
            else
            {
                return null;
            }
        }

        public bool Update(Movie myObject, int id)
        {
            var validResult = valid.Validate(myObject);
            if (validResult.IsValid)
            {
                var movie = dbContext.Movies.Find(id);
                movie = myObject;
                dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
