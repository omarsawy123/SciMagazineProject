using SciMagazine.Core.Entities;
using SciMagazine.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciMagazine.Application.DTOs
{
    public class RegisterRequestDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public UserRole UserRole { get; set; }
        public ICollection<RegisterAttachmentDto> Attachments { get; set; } = new List<RegisterAttachmentDto>();
    }
}
