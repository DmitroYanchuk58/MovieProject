namespace DataAccessLayer.Models
{
    public class MovieEmployee:Entity
    {

        public int IdEmployee { get; set; }

        public Employee Employee { get; set; }

        public int IdMovie { get; set; }

        public Movie Movie { get; set; }

        public bool IsDeleted { get; set; }
    }
}
