using TwitterApi.Bussines.Dtos.FileDtos.Common;

namespace TwitterApi.Bussines.Dtos.FileDtos
{
    public class FileDetailDto : FileBaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string ContentType { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
