namespace TwitterApi.Core.Entities.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
