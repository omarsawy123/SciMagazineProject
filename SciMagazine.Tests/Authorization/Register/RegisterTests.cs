using FluentValidation;
using FluentValidation.TestHelper;
using Moq;
using SciMagazine.Application.DTOs;
using SciMagazine.Application.Enums;
using SciMagazine.Application.Interfaces.IServices;
using SciMagazine.Application.UseCases;
using SciMagazine.Application.Validators;

namespace SciMagazine.Tests.Authorization.Register
{

    public class RegisterTests
    {

        private readonly RegisterRequestDtoValidator _validator;

        public RegisterTests()
        {
            _validator = new RegisterRequestDtoValidator();
        }

        [Fact]
        public void Should_Have_Error_When_UserName_Is_Empty()
        {
            // Arrange
            var request = new RegisterRequestDto { UserName = "", Email = "test@example.com", UserRole = UserRole.Academic };

            
            // Act
            var result = _validator.TestValidate(request);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.UserName);
        }

        [Fact]
        public void Should_Have_Error_When_Email_Is_Empty()
        {
            // Arrange
            var requestEmptyEmail = new RegisterRequestDto
            {
                UserName = "TestUser",
                Email = "",
                UserRole = UserRole.Academic
            };

            // Act
            var result = _validator.TestValidate(requestEmptyEmail);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Should_Have_Error_When_Email_Is_Invalid()
        {
            // Arrange
            var requestInvalidEmail = new RegisterRequestDto
            {
                UserName = "TestUser",
                Email = "t@",
                UserRole = UserRole.Academic
            };

            // Act
            var result = _validator.TestValidate(requestInvalidEmail);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Email);
        }

        [Fact]
        public void Should_Have_No_Error_When_Data_Is_Invalid()
        {
            // Arrange
            var requestInvalidEmail = new RegisterRequestDto
            {
                UserName = "TestUser",
                Email = "t@mail.com",
                UserRole = UserRole.Academic
            };

            // Act
            var result = _validator.TestValidate(requestInvalidEmail);

            // Assert
            result.ShouldNotHaveAnyValidationErrors();
        }



        //[Fact(Skip = "This test is skipped because it is not ready yet.")]
        //public static async Task WhenUserSendsRegisterationRequest_AdminShoulReceiveMail()
        //{
        //    var emailService = new Mock<IEmailServices>();
        //    var validator = new Mock<IValidator<RegisterRequestDto>>();

        //    emailService.Setup(x => x.SendRegisterRequestEmailToAdmin(It.IsAny<RegisterRequestDto>())).ReturnsAsync(true);

        //    var registerService = new RegisterUseCase(emailService.Object, validator.Object);

        //    var request = new RegisterRequestDto
        //    {
        //        // Initialize with appropriate properties
        //        Email = "user@example.com",
        //        UserName = "JohnDoe"
        //    };

        //    await registerService.SendRegisterRequest(request);

        //    emailService.Verify(e => e.SendRegisterRequestEmailToAdmin(It.IsAny<RegisterRequestDto>()), Times.Once());

        //}


    }
}
