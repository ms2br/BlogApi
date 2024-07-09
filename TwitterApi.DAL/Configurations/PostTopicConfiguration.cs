using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterApi.Core.Entities;

namespace TwitterApi.DAL.Configurations
{
    public class PostTopicConfiguration : IEntityTypeConfiguration<PostTopic>
    {
        public void Configure(EntityTypeBuilder<PostTopic> builder)
        {
            builder.Ignore(x => x.Id).Ignore(x => x.IsDeleted);
            builder.HasKey(x => new { x.PostId, x.TopicId });
            
            builder.HasOne(x => x.Topic)
                .WithMany(x => x.Posts) // PostTopics
                .HasForeignKey(x => x.TopicId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.Topics) // PostTopics
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
