using SciMagazine.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciMagazine.Application.DTOs
{
    public class AttachmentDto
    {
        public string Name { get; set; } = string.Empty;
        public string FilePath { get; set; } = string.Empty;
        public string FileType { get; set; } = string.Empty;
    }
}
