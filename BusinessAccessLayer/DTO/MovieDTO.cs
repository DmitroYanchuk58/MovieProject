using DataAccessLayer.Models;
using DataAccessLayer.Data;

namespace BusinessAccessLayer.BusinessObjects
{
    public class MovieDTO
    {
        private MovieDBContext DbContext;

        public MovieDTO()
        {
            throw new Exception("Object can't work without parameters");
        }

        public MovieDTO(MovieDBContext dbContext,Movie movie)
        {
            this.DbContext = dbContext;


            this.Movie = movie;
            GetAverageRate();
            GetComments();
            GetGenres();
            GetVideos();
        }
        public Movie Movie { get; set; }    

        public List<Video> Video { get; set; }

        public List<Comment> Comments { get; set; } 

        public List<Genre> Genres { get; set; }

        public Rate Rate { get; set; }

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

            return genres;
        }

        private List<Comment> GetComments()
        {
            var comments=DbContext.Comments.Where(comment=>comment.IdMovie==Movie.Id).ToList();

            return comments;
        }

        private List<Video> GetVideos()
        {
            var videos=DbContext.Videos.Where(video=>video.IdMovie==Movie.Id).ToList();

            return videos;
        }
        private int GetAverageRate()
        {
            var rates=DbContext.Rates.Where(rate => rate.IdMovie == Movie.Id);

            int averageRate = (int)rates.Average(rate => rate.Evaluation);

            return averageRate;
        }
    }
}
