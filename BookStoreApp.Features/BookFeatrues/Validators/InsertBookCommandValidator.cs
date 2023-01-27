using BookStoreApp.Features.BookFeatrues.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Features.BookFeatrues.Validators
{
    public class InsertBookCommandValidator : AbstractValidator<InsertBookCommand>
    {
        public InsertBookCommandValidator()
        {
            RuleFor(p => p.Title).Length(2, 100).WithMessage("Title length must be between 2 and 100 characters");
            RuleFor(p => p.Description).Length(3, 2000).WithMessage("Description length must be between 3 and 2000 characters");
        }
    }
}
