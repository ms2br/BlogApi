using TwitterApi.Core.Entities.Common;

namespace TwitterApi.Core.Entities
{
    public class Topic : BaseEntity
    {
        public Topic()
        {
            Posts = new HashSet<PostTopic>();
        }

        public string Name { get; set; }
        public string NormalizedTopicName { get; set; }
        public ICollection<PostTopic>? Posts { get; set; }
    }
}
