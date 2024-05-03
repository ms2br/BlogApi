using TwitterApi.Core.Entities.Common;
using TwitterApi.Core.Entities.Identity;

namespace TwitterApi.Core.Entities
{
    public class Blog : BaseEntity
    {
        public Blog()
        {
            Files = new HashSet<FileEntity>();
            Topics = new HashSet<BlogTopic>();
        }
        public string Content { get; set; }
        public string UserId { get; set; }
        public AppUser? AppUser { get; set; }
        public ICollection<FileEntity>? Files { get; set; }
        public ICollection<BlogTopic>? Topics { get; set; }
    }
}
