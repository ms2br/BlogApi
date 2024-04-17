using TwitterApi.Core.Entities.Common;

namespace TwitterApi.Core.Entities
{
    public class BlogTopic : BaseEntity
    {
        public int BlogId { get; set; }
        public int TopicId { get; set; }
        public Blog? Blog { get; set; }
        public Topic? Topic { get; set; }
    }
}
