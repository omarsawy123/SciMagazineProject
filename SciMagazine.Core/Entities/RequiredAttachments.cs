using SciMagazine.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciMagazine.Core.Entities
{
    public class RegisterAttachments 
    {
        public IFileAttachment PersonalId { get; set; }
        public IFileAttachment AcademicCertificate { get; set; }
    }
}
