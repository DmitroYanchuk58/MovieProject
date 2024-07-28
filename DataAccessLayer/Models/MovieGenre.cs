namespace DataAccessLayer.Models
{
    public class MovieGenre:Entity
    {

        public int IdGenre { get; set; }

        public Genre Genre { get; set; }

        public int IdMovie { get; set; }

        public Movie Movie { get; set; }

        public bool IsDeleted { get; set; }
    }
}
