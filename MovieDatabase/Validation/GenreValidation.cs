using FluentValidation;
using MovieDatabase.Models;

namespace MovieDatabase.Validation
{
    public class GenreValidation : Validation<Genre>
    {
        public GenreValidation()
        {
            RuleFor(g => g.Name).NotNull();
            RuleFor(g => g.Id).Must(id => id >= 0);
        }
    }
}
