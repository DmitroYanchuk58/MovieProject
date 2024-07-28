using DataAccessLayer.Models;
using FluentValidation;

namespace DataAccessLayer.Validation
{
    public class Validation<T>: AbstractValidator<T> where T : Entity
    {
        public Validation() {
            RuleFor(o => o.Id).NotEmpty().Must(i => i >= 0);
        }
    }
}
