using MovieDatabase.Models;
using MovieDatabase.Validation;

namespace MovieDatabase.CRUDRepo
{
    public class MovieGenreRepo : IRepo<MovieGenre>
    {
        MovieGenreValidation valid = new MovieGenreValidation();
        Context.MovieDBContext dbContext = new Context.MovieDBContext();

        public bool Create(MovieGenre movieGenre)
        {
            MovieGenre newMovieGenre = new MovieGenre() { Id = dbContext.MovieGenres.Any() ? dbContext.MovieGenres.Max(x => x.Id) + 1 : 0, Movie = movieGenre.Movie, IdMovie = movieGenre.IdMovie, Genre = movieGenre.Genre, IdGenre = movieGenre.IdGenre, IsDeleted = false };
            if (newMovieGenre != null)
            {
                var validResult = valid.Validate(newMovieGenre);
                if (validResult.IsValid)
                {
                    if (dbContext.Movies.Find(newMovieGenre.IdMovie) != null && dbContext.Genres.Find(newMovieGenre.IdGenre) != null)
                    {
                        dbContext.MovieGenres.Add(newMovieGenre);
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
            else
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            var findMovieGenre = dbContext.MovieGenres.Find(id);
            if (findMovieGenre != null)
            {
                var validResult = valid.Validate(findMovieGenre);
                if (validResult.IsValid)
                {
                    findMovieGenre.IsDeleted = true;
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

        public MovieGenre Read(int id)
        {
            var findMovieGenre = dbContext.MovieGenres.Find(id);
            if (findMovieGenre != null && !findMovieGenre.IsDeleted)
            {
                var validResult = valid.Validate(findMovieGenre);
                if (validResult.IsValid)
                {
                    findMovieGenre.Movie = dbContext.Movies.Where(m => m.Id == findMovieGenre.IdMovie).FirstOrDefault();
                    findMovieGenre.Genre = dbContext.Genres.Where(g => g.Id == findMovieGenre.IdGenre).FirstOrDefault();
                    return findMovieGenre;
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

        public bool Update(MovieGenre myObject, int id)
        {
            if (myObject != null)
            {
                var validResult = valid.Validate(myObject);
                if (validResult.IsValid)
                {
                    var movieGenre = dbContext.MovieGenres.Find(id);
                    movieGenre = myObject;
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
