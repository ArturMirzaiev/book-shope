using BookStoreApp.Features.AuthorFeatures.Commands;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BookStoreApp.Features.AuthorFeatures.Validators
{
    public class InsertAuthorCommandValidator : AbstractValidator<InsertAuthorCommand>
    {
        public InsertAuthorCommandValidator()
        {
            RuleFor(p => p.FullName).NotEmpty().Length(3, 50)
                .WithMessage("Fullname length must be between 3 and 50 characters");
            RuleFor(p => p.YearsOfLife).Matches(new Regex("\\d{4}\\-\\d{4}")).WithMessage("Example of property(yearsOfLife): 1234-5678");
        }
    }
}
