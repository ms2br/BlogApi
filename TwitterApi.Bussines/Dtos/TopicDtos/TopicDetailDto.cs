using TwitterApi.Bussines.Dtos.TopicDtos.Common;

namespace TwitterApi.Bussines.Dtos.TopicDtos
{
    public class TopicDetailDto : TopicBaseDto
    {
        public int Id { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
