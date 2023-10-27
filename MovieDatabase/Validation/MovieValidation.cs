using FluentValidation;
using MovieDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Validation
{
    public class MovieValidation: AbstractValidator<Movie>
    {
        public MovieValidation() {
            RuleFor(m => m.Name).NotNull().MaximumLength(1000).MinimumLength(1);
            RuleFor(m=>m.Description).NotNull().MaximumLength(10000).MinimumLength(10);
        }
    }
}
