using TwitterApi.Core.Entities.Common;

namespace TwitterApi.Core.Entities
{
    public class Topic : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<BlogTopic> BlogTopics { get; set; }
    }
}
