using FluentValidation;
using MovieDatabase.Models;

namespace MovieDatabase.Validation
{
    public class MovieGenreValidation : Validation<MovieGenre>
    {
        public MovieGenreValidation()
        {
            RuleFor(mg => mg.IdMovie).NotNull();
            RuleFor(mg => mg.IdGenre).NotNull();
        }
    }
}
