using SciMagazine.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciMagazine.Application.Interfaces.IServices
{
    public interface IEmailServices
    {
        Task<bool> SendRegisterRequestEmailToAdmin(RegisterRequestDto request);
    }
}
