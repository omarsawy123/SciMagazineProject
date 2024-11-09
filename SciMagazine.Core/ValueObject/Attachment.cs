using SciMagazine.Core.Interfaces;

namespace SciMagazine.Core.ValueObject
{
    public class Attachment : IFileAttachment
    {
        public string Name { get; }
        public string FileType { get; }

        public string FilePath { get; }
    }
}
