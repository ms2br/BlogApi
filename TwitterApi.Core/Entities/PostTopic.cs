using TwitterApi.Core.Entities.Common;

namespace TwitterApi.Core.Entities
{
    public class PostTopic : BaseEntity
    {
        public int PostId { get; set; }
        public int TopicId { get; set; }
        public Post? Post { get; set; }
        public Topic? Topic { get; set; }
    }
}
