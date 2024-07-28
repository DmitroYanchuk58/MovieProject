using FluentValidation;
using DataAccessLayer.Models;

namespace DataAccessLayer.Validation
{
    public class EmployeeValidation : Validation<Employee>
    {
        public EmployeeValidation()
        {
            RuleFor(e => e.Name).NotNull().MinimumLength(1).MaximumLength(100);
            RuleFor(e => e.Surname).NotNull().MinimumLength(1).MaximumLength(100);
        }
    }
}
