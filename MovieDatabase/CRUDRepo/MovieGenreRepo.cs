using MovieDatabase.Models;
using MovieDatabase.Validation;

namespace MovieDatabase.CRUDRepo
{
    //public class MovieGenreRepo:IRepo<MovieGenre>
    //{
    //    ModelValidation validation = new ModelValidation();
    //    Context.MovieDBContext dbContext = new Context.MovieDBContext();

    //    public bool Create(MovieGenre movieGenre)
    //    {
    //        MovieGenre newMovieGenre = new MovieGenre() { Id = dbContext.MovieGenres.Any() ? dbContext.MovieGenres.Max(x => x.Id) + 1 : 0, Movie=movieGenre.Movie,IdMovie=movieGenre.IdMovie,Genre=movieGenre.Genre,IdGenre=movieGenre.IdGenre};
    //        if (validation.ValidationMovieGenre(newMovieGenre))
    //        {
    //            dbContext.MovieGenres.Add(newMovieGenre);
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
    //        var findMovieGenre = dbContext.MovieGenres.Find(id);
    //        if (validation.ValidationMovieGenre(findMovieGenre))
    //        {
    //            dbContext.Remove(findMovieGenre);
    //            dbContext.SaveChanges();
    //            return true;
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }

    //    public MovieGenre Read(int id)
    //    {
    //        var findMovieGenre = dbContext.MovieGenres.Find(id);
    //        if (validation.ValidationMovieGenre(findMovieGenre))
    //        {
    //            return findMovieGenre;
    //        }
    //        else
    //        {
    //            return null;
    //        }
    //    }

    //    public bool Update(MovieGenre myObject, int id)
    //    {
    //        if (validation.ValidationMovieGenre(myObject))
    //        {
    //            var movieGenre = dbContext.MovieGenres.Find(id);
    //            movieGenre = myObject;
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
