using MovieDatabase.Models;

namespace MovieDatabase.ViewModel
{
    public class MovieWithRateVM
    {
        public Movie Movie { get; set; }
        public double? AverageRate { get; set; }
    }
}
