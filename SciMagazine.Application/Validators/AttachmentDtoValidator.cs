using FluentValidation;
using SciMagazine.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciMagazine.Application.Validators
{
    public class AttachmentDtoValidator : AbstractValidator<AttachmentDto>
    {
        public AttachmentDtoValidator()
        {
            // Validate Name
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Attachment Name is required.");

            // Validate FilePath
            RuleFor(x => x.FilePath)
                .NotEmpty().WithMessage("FilePath is required.");

            // Validate FileType
            RuleFor(x => x.FileType)
                .NotEmpty().WithMessage("FileType is required.");
        }

        // Custom validator for file path
        private bool BeAValidPath(string filePath)
        {
            return !string.IsNullOrWhiteSpace(filePath) && Path.IsPathRooted(filePath);
        }
    }
}
