using SciMagazine.Core.Interfaces;
using SciMagazine.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciMagazine.Core.Entities
{
    public class RegisterAttachments 
    {
        public Attachment PersonalId { get; set; }
        public Attachment AcademicCertificate { get; set; }
    }
}
