using FluentValidation;
using MovieDatabase.Models;

namespace MovieDatabase.Validation
{
    public class MovieEmployeeValidation : AbstractValidator<MovieEmployee>
    {
        public MovieEmployeeValidation()
        {
            RuleFor(me => me.IdEmployee).NotNull();
            RuleFor(me => me.IdMovie).NotNull();
        }
    }
}
