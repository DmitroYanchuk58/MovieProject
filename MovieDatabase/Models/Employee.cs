namespace MovieDatabase.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public ICollection<MovieEmployee> MovieEmployees { get; set; }
    }
}
