using FluentValidation;
using SciMagazine.Application.DTOs;
using SciMagazine.Application.Interfaces.IServices;
using SciMagazine.Application.Interfaces.IUseCases;

namespace SciMagazine.Application.UseCases
{
    public class RegisterUseCase : IRegisterUseCase
    {
        private readonly IEmailServices _emailServices;
        private readonly IValidator<RegisterRequestDto> _validator;

        public RegisterUseCase(IEmailServices emailServices,IValidator<RegisterRequestDto> validator)
        {
            _emailServices = emailServices;
            _validator = validator;
        }

        public async Task<bool> SendRegisterRequest(RegisterRequestDto request)
        {
            var validationResult = _validator.Validate(request);
            
            if (!validationResult.IsValid)
            {
                return false;
            }

            return true;
        }
    }
}
