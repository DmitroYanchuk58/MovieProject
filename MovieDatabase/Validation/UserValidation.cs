using FluentValidation;
using MovieDatabase.Models;

namespace MovieDatabase.Validation
{
    public class UserValidation : AbstractValidator<User>
    {
        public UserValidation()
        {
            RuleFor(u => u.Id).Must(id => id >= 0);
            RuleFor(u => u.Nickname).NotNull().MinimumLength(1).MaximumLength(100);
            RuleFor(u => u.Password).NotNull().MinimumLength(5).MaximumLength(100);
        }
    }
}
