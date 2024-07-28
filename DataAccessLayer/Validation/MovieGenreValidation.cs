using FluentValidation;
using DataAccessLayer.Models;

namespace DataAccessLayer.Validation
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
