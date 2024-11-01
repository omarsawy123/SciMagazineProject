using FluentValidation;
using SciMagazine.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciMagazine.Application.Validators
{
    public class RegisterRequestDtoValidator :  AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestDtoValidator()
        {
            // Rule for UserName - it should not be null, empty, or whitespace
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User name cannot be empty.")
                .Must(name => name.Trim().Length > 0).WithMessage("User name cannot be whitespace.")
                .MaximumLength(50).WithMessage("User name cannot exceed 50 characters.")
                .WithMessage("User name is required.");

            // Rule for Email - it should be a valid email format
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            // Rule for UserRole - ensure it is a valid enum value
            RuleFor(x => x.UserRole)
                .IsInEnum().WithMessage("Invalid user role specified.");
        }
    }
}
