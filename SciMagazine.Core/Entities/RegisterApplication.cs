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
        public User AssignedUser { get; set; }
    }
}
