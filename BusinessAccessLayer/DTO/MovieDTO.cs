using DataAccessLayer.Models;
using DataAccessLayer.Data;
using Microsoft.IdentityModel.Tokens;

namespace BusinessAccessLayer.BusinessObjects
{
    public class MovieDTO
    {
        private MovieDBContext DbContext;

        public MovieDTO()
        {
            throw new Exception("Object can't work without parameters");
        }

        public MovieDTO(MovieDBContext dbContext,int idMovie)
        {
            this.DbContext = dbContext;
            this.Movie = DbContext.Movies.Find(idMovie);
            if (this.Movie != null)
            {
                this.Rate=GetAverageRate();
                this.Comments=GetComments();
                this.Genres=GetGenres();
                this.Video=GetVideos();
                this.Employees = GetEmployees();
            }
        }
        public Movie Movie { get; set; }    

        public List<Video> Video { get; set; }

        public List<Comment> Comments { get; set; } 

        public List<Genre> Genres { get; set; }

        public List<Employee> Employees { get; set; }

        public int Rate { get; set; }

        private List<Genre> GetGenres()
        {
            var genres=DbContext.Genres.Join(
                DbContext.MovieGenres,
                genre=>genre.Id,
                movieGenre=>movieGenre.IdGenre,
                (genre,movieGenre)=>new {genre, movieGenre})
                .Where(join=>join.movieGenre.IdMovie==Movie.Id)
                .Select(join=>join.genre)
                .ToList();

            if (genres.IsNullOrEmpty()&&genres.Count==0)
            {
                return null;
            }

            return genres;
        }

        private List<Employee> GetEmployees()
        {
            var employees = DbContext.Employees.Join(
                DbContext.MovieEmployees,
                employee => employee.Id,
                movieEmployee => movieEmployee.IdEmployee,
                (employee, MovieEmployee) => new { employee, MovieEmployee })
                .Where(join => join.MovieEmployee.IdMovie == Movie.Id)
                .Select(join => join.employee)
                .ToList();

            if (employees.IsNullOrEmpty() && employees.Count == 0)
            {
                return null;
            }

            return employees;
        }

        private List<Comment> GetComments()
        {
            var comments=DbContext.Comments.Where(comment=>comment.IdMovie==Movie.Id).ToList();

            if (comments.IsNullOrEmpty() && comments.Count == 0)
            {
                return null; 
            }

            return comments.ToList();
        }

        private List<Video> GetVideos()
        {
            var videos =DbContext.Videos.Where(video=>video.IdMovie==Movie.Id).ToList();

            if (videos.IsNullOrEmpty() && videos.Count == 0)
            {
                return null;
            }

            return videos.ToList();
        }
        private int GetAverageRate()
        {
            var rates=DbContext.Rates.Where(rate => rate.IdMovie == Movie.Id).ToList();
            if (rates.IsNullOrEmpty() && rates.Count == 0)
            {
                return 0;
            }

            int averageRate = (int)rates.Average(rate => rate.Evaluation);

            return averageRate;
        }
    }
}
