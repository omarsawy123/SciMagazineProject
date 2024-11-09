using FluentValidation;
using SciMagazine.Application.DTOs;
using SciMagazine.Core.Interfaces;

namespace SciMagazine.Application.Validators
{
    public class RegisterRequestDtoValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestDtoValidator()
        {
            // Rule for UserName - it should not be null, empty, or whitespace
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User name cannot be empty.");
                

            // Rule for Email - it should be a valid email format
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            // Rule for UserRole - ensure it is a valid enum value
            RuleFor(x => x.UserRole).IsInEnum().WithMessage("Invalid user role specified.");


            RuleFor(x => x.Attachments)
                .NotNull().WithMessage("Registeration Attachments are required");

            RuleFor(x => x.Attachments.PersonalId).NotNull().WithMessage("PersonalId is required")
                 .When(x => x.Attachments != null);

            RuleFor(x => x.Attachments.AcademicCertificate).NotNull().WithMessage("PersonalId is required")
                 .When(x => x.Attachments != null);

        }


    }
}
