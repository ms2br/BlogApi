using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterApi.Core.Entities;

namespace TwitterApi.DAL.Configurations
{
    public class BlogTopicConfiguration : IEntityTypeConfiguration<BlogTopic>
    {
        public void Configure(EntityTypeBuilder<BlogTopic> builder)
        {
            builder.Ignore(x => x.Id).Ignore(x => x.IsDeleted);
            builder.HasKey(x => new { x.BlogId, x.TopicId });

            builder.HasOne(x => x.Topic)
                .WithMany(x => x.BlogTopics)
                .HasForeignKey(x => x.TopicId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Blog)
                .WithMany(x => x.BlogTopics)
                .HasForeignKey(x => x.BlogId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
