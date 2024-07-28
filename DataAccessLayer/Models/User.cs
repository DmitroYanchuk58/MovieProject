namespace DataAccessLayer.Models
{
    public class User:Entity
    {

        public string Nickname { get; set; }

        public string Password { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Rate> Rates { get; set; }

        public bool IsDeleted { get; set; }
    }
}
