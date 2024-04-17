namespace TwitterApi.Bussines.Dtos.TopicDtos
{
    public class TopicDetailDto
    {
        public int Id { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
