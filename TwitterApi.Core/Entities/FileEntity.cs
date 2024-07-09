using TwitterApi.Core.Entities.Common;

namespace TwitterApi.Core.Entities
{
    public class FileEntity : BaseEntity
    {
        public string ContentType { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public int PostId { get; set; }
        public Post? Post { get; set; }
    }
}
