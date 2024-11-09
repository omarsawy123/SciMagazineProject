using SciMagazine.Application.Enums;
using SciMagazine.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciMagazine.Application.DTOs
{
    public class RegisterRequestDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public UserRole UserRole { get; set; }
        public RegisterAttachments Attachments { get; set; } 
    }
}
