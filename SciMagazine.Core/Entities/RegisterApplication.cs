using SciMagazine.Core.Common.Classes;
using SciMagazine.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciMagazine.Core.Entities
{
    public class RegisterApplication
    {
        public int Id { get; set; }
        public ApplicationStatus Status { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public UserRole UserRole { get; set; }
        public ICollection<RegisterAttachment> Attachments { get; set; } = new List<RegisterAttachment>();
    }
}
