
using SciMagazine.Core.Enums;

namespace SciMagazine.Core.Entities
{
    public class RequiredAttachment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RequiredAttachmentType Type { get; set; }
    }
}
