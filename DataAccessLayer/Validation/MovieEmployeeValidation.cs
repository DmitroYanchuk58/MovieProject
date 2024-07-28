using FluentValidation;
using DataAccessLayer.Models;

namespace DataAccessLayer.Validation
{
    public class MovieEmployeeValidation : Validation<MovieEmployee>
    {
        public MovieEmployeeValidation()
        {
            RuleFor(me => me.IdEmployee).NotNull();
            RuleFor(me => me.IdMovie).NotNull();
        }
    }
}
