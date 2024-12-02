using SciMagazine.Core.Enums;

namespace SciMagazine.Core.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public string Name { get;set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }
        public EntityType EntityType { get; set; }
        public int EntityId { get; set; }

    }
}
