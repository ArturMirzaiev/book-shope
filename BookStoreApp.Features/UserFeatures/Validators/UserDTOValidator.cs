using BookStoreApp.Data.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreApp.Features.UserFeatures.Validators
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().Length(2, 30)
                .WithMessage("UserName must be between 2 and 30 characters");
            RuleFor(p => p.FirstName).NotEmpty().Length(2, 30)
                .WithMessage("FirstName must be between 2 and 30 characters");
            RuleFor(p => p.LastName).NotEmpty().Length(2, 30)
                .WithMessage("LastName must be between 2 and 30 characters");
            RuleFor(p => p.Email).NotEmpty().Length(6, 50)
                .Matches("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$")
                .WithMessage("Email written incorrectly");
            RuleFor(p => p.Password).NotEmpty().Length(6, 14)
                .WithMessage("Password must be between 6 and 14 characters");
        }
    }
}
