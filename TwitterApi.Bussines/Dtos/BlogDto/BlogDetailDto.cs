using TwitterApi.Bussines.Dtos.FileDtos;
using TwitterApi.Bussines.Dtos.TopicDtos;

namespace TwitterApi.Bussines.Dtos.BlogDto
{
    public class BlogDetailDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public IEnumerable<TopicDetailDto> Topics { get; set; }
        public IEnumerable<FileDetailDto> Files { get; set; }
    }
}
