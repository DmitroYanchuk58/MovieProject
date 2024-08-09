using FluentValidation;
using DataAccessLayer.Models;

namespace DataAccessLayer.Validation
{
    public class MovieValidation : Validation<Movie>
    {
        public MovieValidation()
        {
            RuleFor(m => m.Name).NotNull().MaximumLength(1000).MinimumLength(1);
            RuleFor(m => m.Description).NotNull().MaximumLength(100000).MinimumLength(10);
        }
    }
}
