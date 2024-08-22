using DataAccessLayer.Data;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.DTO
{
    public class GenreDTO
    {
        private MovieDBContext DbContext;

        public Genre Genre { get; set; }

        public List<Movie> Movies {  get; set; }

        public GenreDTO(MovieDBContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public GenreDTO(MovieDBContext dbContext,int idGenre)
        {
            this.DbContext = dbContext;
            GetGenre(idGenre);
        }

        private void GetGenre(int idGenre)
        {
            this.Genre = DbContext.Genres.Find(idGenre);
            if (Genre != null)
            {
                this.Movies = GetMovies();
            }
        }

        private List<Movie> GetMovies()
        {
            var genres = DbContext.Movies.Join(
                DbContext.MovieGenres,
                movie => movie.Id,
                movieGenre => movieGenre.IdGenre,
                (movie, movieGenre) => new { movie, movieGenre })
                .Where(join => join.movieGenre.IdGenre==this.Genre.Id)
                .Select(join => join.movie)
                .ToList();

            if (genres.IsNullOrEmpty() && genres.Count() == 0)
            {
                return null;
            }

            return genres;  
        }

    }
}
