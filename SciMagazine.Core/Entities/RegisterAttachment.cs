using SciMagazine.Core.Enums;

namespace SciMagazine.Core.Entities
{
    public class RegisterAttachment
    {
        public int Id { get; set; }
        public int AttachmentId { get; set; }
        public Attachment Attachment { get; set; } = null!;
        public RequiredAttachmentType Type { get; set; }
        public int ApplicationId { get; set; }
        public RegisterApplication RegisterApplication { get; set; } = null!;
    }
}
