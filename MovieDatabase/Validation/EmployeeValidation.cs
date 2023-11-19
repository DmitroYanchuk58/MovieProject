using FluentValidation;
using MovieDatabase.Models;

namespace MovieDatabase.Validation
{
    public class EmployeeValidation : AbstractValidator<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(e => e.Name).NotNull().MinimumLength(1).MaximumLength(100);
            RuleFor(e => e.Surname).NotNull().MinimumLength(1).MaximumLength(100);
        }
    }
}
