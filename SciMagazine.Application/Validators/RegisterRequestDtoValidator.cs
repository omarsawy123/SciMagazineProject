using FluentValidation;
using SciMagazine.Application.DTOs;
using SciMagazine.Core.Enums;

namespace SciMagazine.Application.Validators
{
    public class RegisterRequestDtoValidator : AbstractValidator<RegisterRequestDto>
    {
        public RegisterRequestDtoValidator()
        {
            // Rule for UserName - it should not be null, empty, or whitespace
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User name cannot be empty.")
                .MaximumLength(200).WithMessage("User name cannot be more than 200 characters")
                .MinimumLength(3).WithMessage("User name cannot be less than 3 characters");
                

            // Rule for Email - it should be a valid email format
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            // Rule for UserRole - ensure it is a valid enum value
            RuleFor(x => x.UserRole).IsInEnum().WithMessage("Invalid user role specified.");


            RuleFor(x => x.Attachments)
                .Must(x => x.Any(a => a.RequiredAttachmentType == RequiredAttachmentType.AcademicCertificate))
                .WithMessage($"The following attachment is required : {Enum.GetName(RequiredAttachmentType.AcademicCertificate)}")
                .Must(x => x.Any(a => a.RequiredAttachmentType == RequiredAttachmentType.PersonalId))
                .WithMessage($"The following attachment is required : {Enum.GetName(RequiredAttachmentType.PersonalId)}");
                

            RuleForEach(x => x.Attachments)
                .SetValidator(new RegisterAttachmentDtoValidator());
                
        }

    }

    public class RegisterAttachmentDtoValidator : AbstractValidator<RegisterAttachmentDto>
    {
        public RegisterAttachmentDtoValidator()
        {
            // Validate RequiredAttachmentType
            RuleFor(x => x.RequiredAttachmentType)
                .NotNull().WithMessage("Attachment type is required.");

            // Include base class validator
            Include(new AttachmentDtoValidator());
        }
    }

    
}
