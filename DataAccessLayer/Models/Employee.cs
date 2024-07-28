namespace DataAccessLayer.Models
{
    public class Employee:Entity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<MovieEmployee> MovieEmployees { get; set; }

        public bool IsDeleted { get; set; }
    }
}
