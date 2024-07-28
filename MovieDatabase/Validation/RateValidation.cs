using FluentValidation;
using MovieDatabase.Models;

namespace MovieDatabase.Validation
{
    public class RateValidation : Validation<Rate>
    {
        public RateValidation()
        {
            RuleFor(r => r.Evaluation).NotNull().Must(r => r >= 0 && r <= 100);
            RuleFor(r => r.IdMovie).NotNull().Must(id => id >= 0);
            RuleFor(r => r.IdUser).NotNull().Must(id => id >= 0);
        }
    }
}
