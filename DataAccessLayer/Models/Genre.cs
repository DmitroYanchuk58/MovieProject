namespace DataAccessLayer.Models
{
    public class Genre:Entity
    {

        public string Name { get; set; }

        public ICollection<MovieGenre> MovieGenres { get; set; }

        public bool IsDeleted { get; set; }
    }
}
