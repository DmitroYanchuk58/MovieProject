using FluentValidation;
using DataAccessLayer.Models;

namespace DataAccessLayer.Validation
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
