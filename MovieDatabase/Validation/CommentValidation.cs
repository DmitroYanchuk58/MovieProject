using FluentValidation;
using MovieDatabase.Models;

namespace MovieDatabase.Validation
{
    public class CommentValidation : AbstractValidator<Comment>
    {
        public CommentValidation()
        {
            RuleFor(c => c.IdMovie).NotNull();
            RuleFor(c => c.IdUser).NotNull();
            RuleFor(c => c.Text).NotNull().MinimumLength(1).MaximumLength(5000);
        }
    }
}
