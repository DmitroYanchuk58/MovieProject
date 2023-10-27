namespace MovieDatabase.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Video> Videos { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rate> Rates { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; }

        public ICollection<MovieEmployee> MovieEmployees { get; set; }
    }
}
