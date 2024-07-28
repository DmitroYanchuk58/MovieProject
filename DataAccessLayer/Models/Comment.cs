namespace DataAccessLayer.Models
{
    public class Comment:Entity
    {
        public int IdUser { get; set; }

        public User User { get; set; }

        public int IdMovie { get; set; }

        public Movie Movie { get; set; }

        public string Text { get; set; }

        public bool IsDeleted { get; set; }
    }
}
