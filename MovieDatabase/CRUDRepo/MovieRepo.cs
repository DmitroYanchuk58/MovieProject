using MovieDatabase.Models;
using MovieDatabase.Validation;
using MovieDatabase.ViewModel;

namespace MovieDatabase.CRUDRepo
{
    public class MovieRepo : IRepo<Movie>
    {
        MovieValidation valid = new MovieValidation();
        Context.MovieDBContext dbContext = new Context.MovieDBContext();

        public bool Create(Movie movie)
        {
            Movie newMovie = new Movie() { Name = movie.Name, Description = movie.Description, IsDeleted = false };
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
                    findMovie.IsDeleted = true;
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
            if (findMovie != null && !findMovie.IsDeleted)
            {
                var validResult = valid.Validate(findMovie);
                if (validResult.IsValid)
                {
                    findMovie.Comments = dbContext.Comments.Where(c => c.IdMovie == id).ToList();
                    findMovie.Rates = dbContext.Rates.Where(r => r.IdMovie == id).ToList();
                    findMovie.MovieEmployees = dbContext.MovieEmployees.Where(me => me.IdMovie == id).ToList();
                    findMovie.MovieGenres = dbContext.MovieGenres.Where(mg => mg.IdMovie == id).ToList();
                    findMovie.Videos = dbContext.Videos.Where(v => v.IdMovie == id).ToList();
                    return findMovie;
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

        public bool Update(Movie myObject, int id)
        {
            if (myObject != null)
            {
                var validResult = valid.Validate(myObject);
                if (validResult.IsValid)
                {
                    var movie = dbContext.Movies.Find(id);
                    if (movie != null)
                    {
                        movie.Name = myObject.Name;
                        movie.Description = myObject.Description;
                        dbContext.SaveChanges();
                        return true;
                    }
                    else { return false; }
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
        public List<MovieWithRateVM> GetMostRateMovie()
        {
            return dbContext.Movies
    .Where(mg => mg.IsDeleted == false)
    .GroupJoin(dbContext.Rates,
        mg => mg.Id,
        r => r.IdMovie,
        (mg, rates) => new
        {
            Movie = mg,
            AverageRate = rates.DefaultIfEmpty().Average(r => r.Evaluation)
        })
    .Select(group => new MovieWithRateVM
    {
        Movie = group.Movie,
        AverageRate = group.AverageRate
    })
    .OrderByDescending(mg => mg.AverageRate)
    .ToList();
        }
        public List<MovieWithGenreVM> GetMovieByGenre(int id)
        {
            GenreRepo repo = new GenreRepo();
            return dbContext.Movies
                .Join(dbContext.MovieGenres, m => m.Id, mg => mg.IdMovie, (m, mg) => new { Movie = m, MovieGenre = mg })
                .Where(mg => mg.MovieGenre.IdGenre == id && mg.Movie.IsDeleted == false)
                .Select(mg => new MovieWithGenreVM { Movie = mg.Movie, Genre = repo.Read(mg.MovieGenre.IdGenre).Name })
                .ToList();
        }

        public List<MovieWithEmployeeVM> GetMovieByActor(int idActor)
        {
            return dbContext.Movies
                .Join(dbContext.MovieEmployees, m => m.Id, me => me.IdMovie, (m, me) => new { Movie = m, MovieEmployee = me })
                .Where(m => m.Movie.IsDeleted == false && m.MovieEmployee.IdEmployee == idActor)
                .Select(m => new MovieWithEmployeeVM { Movie = m.Movie, Employee = dbContext.Employees.Where(e => e.Id == m.MovieEmployee.IdEmployee).FirstOrDefault() })
                .ToList();
        }
        public List<Movie> GetMovieByCountComment()
        {
            return dbContext.Movies
                .Where(m => m.IsDeleted == false)
                .OrderByDescending(m => m.Comments.Count)
                .ToList();
        }

    }
}
