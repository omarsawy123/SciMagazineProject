using FluentValidation.TestHelper;
using SciMagazine.Application.DTOs;
using SciMagazine.Core.Enums;
using SciMagazine.Application.Validators;
using SciMagazine.Core.Entities;

namespace SciMagazine.Tests.Authorization.Register
{

    public class RegisterTests
    {

        private readonly RegisterRequestDtoValidator _validator;

        public RegisterTests()
        {
            _validator = new RegisterRequestDtoValidator();
        }

    }
}
