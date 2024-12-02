using SciMagazine.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciMagazine.Application.DTOs
{
    public class RegisterAttachmentDto : AttachmentDto
    {
        public RequiredAttachmentType? RequiredAttachmentType { get; set; }

    }
}
