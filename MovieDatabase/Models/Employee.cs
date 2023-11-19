namespace MovieDatabase.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<MovieEmployee> MovieEmployees { get; set; }

        public bool IsDeleted { get; set; }
    }
}
