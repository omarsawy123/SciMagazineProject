using SciMagazine.Application.Interfaces.IServices;
using SciMagazine.Core.Entities;
using SciMagazine.Core.Enums;
using SciMagazine.Infrastructure.Data;


namespace SciMagazine.Infrastructure.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly ApplicationDbContext _context;

        public AttachmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAttachment(int entityId, EntityType entityType, string filePath, string fileType, string fileName)
        {

            var attachment = new Attachment()
            {
                EntityType = entityType,
                EntityId = entityId,
                FilePath = filePath,
                FileType = fileType,
                Name = fileName
            };

            await _context.Attachments.AddAsync(attachment);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
