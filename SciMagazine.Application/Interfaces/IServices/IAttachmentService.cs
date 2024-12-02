using SciMagazine.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciMagazine.Application.Interfaces.IServices
{
    public interface IAttachmentService
    {
        Task<bool> AddAttachment(int entityId,EntityType entityType,string filePath,string fileType,string fileName);
    }
}
