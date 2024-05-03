using TwitterApi.Core.Entities.Common;

namespace TwitterApi.Core.Entities
{
    public class Topic : BaseEntity
    {
        public Topic()
        {
            Blogs = new HashSet<BlogTopic>();
        }

        public string Name { get; set; }
        public ICollection<BlogTopic>? Blogs { get; set; }
    }
}
