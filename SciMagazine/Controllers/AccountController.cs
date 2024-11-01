using Microsoft.AspNetCore.Mvc;
using SciMagazine.Application.DTOs;
using SciMagazine.Application.Interfaces.IServices;
using SciMagazine.Application.Interfaces.IUseCases;

namespace SciMagazine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly IRegisterUseCase _registerUseCase;
        public AccountController(IRegisterUseCase registerUseCase)
        {
            _registerUseCase = registerUseCase;
        }

        [HttpPost("send-register-request")]
        public async Task<IActionResult> SendRegisterRequest(RegisterRequestDto request)
        {
            var result = await _registerUseCase.SendRegisterRequest(request);
            return Ok(result);
        }
    }
}
