using TwitterApi.Core.Entities.Common;

namespace TwitterApi.Core.Entities
{
    public class Topic : BaseEntity
    {
        public Topic()
        {
            BlogTopics = new HashSet<BlogTopic>();
        }

        public string Name { get; set; }
        public ICollection<BlogTopic>? BlogTopics { get; set; }
    }
}
