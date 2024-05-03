using TwitterApi.Bussines.Dtos.FileDtos;
using TwitterApi.Bussines.Dtos.TopicDtos;
using TwitterApi.Bussines.Dtos.UserDtos;
using TwitterApi.Core.Entities.Identity;

namespace TwitterApi.Bussines.Dtos.BlogDtos
{
    public class BlogDetailDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public UserPostDto AppUser { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public IEnumerable<FileDetailDto> Files { get; set; }
        public IEnumerable<TopicDetailDto> TopicDetails { get; set; }
    }
}
