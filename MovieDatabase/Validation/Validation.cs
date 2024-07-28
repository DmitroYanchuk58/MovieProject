using MovieDatabase.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Validation
{
    public class Validation<T>: AbstractValidator<T> where T : Entity
    {
        public Validation() {
            RuleFor(o => o.Id).NotEmpty().Must(i => i >= 0);
        }
    }
}
