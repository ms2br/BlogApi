using TwitterApi.Core.Entities.Common;
using TwitterApi.Core.Entities.Identity;

namespace TwitterApi.Core.Entities
{
    public class Post : BaseEntity
    {
        public Post()
        {
            Files = new HashSet<FileEntity>();
            Topics = new HashSet<PostTopic>();
            PostReactions = new HashSet<PostReaction>();
        }

        public string Content { get; set; }
        public string UserId { get; set; }
        public AppUser? AppUser { get; set; }
        public ICollection<FileEntity>? Files { get; set; }
        public ICollection<PostTopic>? Topics { get; set; }
        public ICollection<PostReaction> PostReactions { get; set; }
    }
}
