using DataAccessLayer.Models;
using FluentValidation;

namespace DataAccessLayer.Validation
{
    public class Validation<T>: AbstractValidator<T> where T : Entity
    {
        public Validation() {
            RuleFor(i=>i.IsDeleted).NotEqual(true);
        }
    }
}
