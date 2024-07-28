namespace DataAccessLayer.Models
{
    public class Rate:Entity
    {

        public int Evaluation { get; set; }

        public int IdUser { get; set; }

        public User User { get; set; }

        public int IdMovie { get; set; }

        public Movie Movie { get; set; }

        public bool IsDeleted { get; set; }
    }
}
