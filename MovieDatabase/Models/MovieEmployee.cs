namespace MovieDatabase.Models
{
    public class MovieEmployee
    {
        public int Id { get; set; }

        public int IdEmployee { get; set; }

        public Employee Employee { get; set; }

        public int IdMovie { get;set; }

        public Movie Movie { get; set; }
    }
}
