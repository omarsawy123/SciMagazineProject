using FluentValidation.TestHelper;
using SciMagazine.Application.DTOs;
using SciMagazine.Application.Validators;
using SciMagazine.Core.Entities;
using SciMagazine.Core.Enums;

namespace SciMagazine.Tests.Authorization.Register
{
    public class RegisterTests
    {
        private readonly RegisterRequestDtoValidator _validator;

        public RegisterTests()
        {
            _validator = new RegisterRequestDtoValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void UserName_ShouldHaveValidationError_WhenEmpty(string userName)
        {
            var request = new RegisterRequestDto { UserName = userName };
            var result = _validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.UserName);
        }

        [Fact]
        public void UserName_ShouldHaveValidationError_WhenLessThanThreeCharacters()
        {
            var request = new RegisterRequestDto { UserName = "ab" }; // Less than 3 characters
            var result = _validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.UserName);
        }

        [Fact]
        public void UserName_ShouldHaveValidationError_WhenMoreThanTwoHundredCharacters()
        {
            var request = new RegisterRequestDto { UserName = new string('a', 201) }; // More than 200 characters
            var result = _validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.UserName);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("invalid-email")]
        [InlineData("invalid@")]
        [InlineData("@invalid.com")]
        public void Email_ShouldHaveValidationError_WhenInvalidFormat(string email)
        {
            var request = new RegisterRequestDto { Email = email };
            var result = _validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void UserRole_ShouldHaveValidationError_WhenInvalidEnumValue()
        {
            var request = new RegisterRequestDto { UserRole = (UserRole)999 }; // Invalid enum value
            var result = _validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.UserRole);
        }

        [Fact]
        public void Attachments_ShouldHaveValidationError_WhenEmpty()
        {
            var request = new RegisterRequestDto
            {
                UserName = "ValidName",
                Email = "valid@email.com",
                UserRole = UserRole.Academic,
                Attachments = new List<RegisterAttachmentDto>(), // Empty attachments
            };

            var result = _validator.TestValidate(request);
            result.ShouldHaveAnyValidationError();
        }

        [Fact]
        public void Attachments_ShouldHaveValidationError_WhenMissingAcademicCertificate()
        {
            var request = new RegisterRequestDto
            {
                UserName = "ValidName",
                Email = "valid@email.com",
                UserRole = UserRole.Academic,
                Attachments = new List<RegisterAttachmentDto>
                {
                    new()
                    {
                        Name = "Personal ID",
                        FilePath = "path/to/file",
                        FileType = ".pdf",
                        RequiredAttachmentType = RequiredAttachmentType.PersonalId,
                    },
                },
            };

            var result = _validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(x => x.Attachments);
        }

        [Fact]
        public void RegisterRequest_ShouldPass_WhenAllPropertiesAreValid()
        {
            var request = new RegisterRequestDto
            {
                UserName = "ValidName",
                Email = "valid@email.com",
                UserRole = UserRole.Academic,
                Attachments = new List<RegisterAttachmentDto>
                {
                    new()
                    {
                        Name = "Personal ID",
                        FilePath = "path/to/file1",
                        FileType = ".pdf",
                        RequiredAttachmentType = RequiredAttachmentType.PersonalId,
                    },
                    new()
                    {
                        Name = "Academic Certificate",
                        FilePath = "path/to/file2",
                        FileType = ".pdf",
                        RequiredAttachmentType = RequiredAttachmentType.AcademicCertificate,
                    },
                },
            };

            var result = _validator.TestValidate(request);
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
