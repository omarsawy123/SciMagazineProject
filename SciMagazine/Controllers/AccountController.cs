using Microsoft.AspNetCore.Mvc;
using SciMagazine.Application.DTOs;
using SciMagazine.Application.Interfaces.IServices;

namespace SciMagazine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly IEmailServices _emailServices;
        public AccountController(IEmailServices emailServices)
        {
            _emailServices = emailServices;
        }

        [HttpPost("send-register-request")]
        public async Task<IActionResult> SendRegisterRequest(RegisterRequestEmail request)
        {
            var result = await _emailServices.SendApprovalEmailToAdmin(request);
            return Ok(result);
        }
    }
}
