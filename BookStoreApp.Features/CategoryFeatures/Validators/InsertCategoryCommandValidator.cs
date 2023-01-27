using BookStoreApp.Features.CategoryFeatures.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Features.CategoryFeatures.Validators
{
    public class InsertCategoryCommandValidator : AbstractValidator<InsertCategoryCommand>
    {
        public InsertCategoryCommandValidator()
        {
            RuleFor(p => p.Name).Length(2, 30).WithMessage("Name length must be between 3 and 30 characters");
        }
    }
}
