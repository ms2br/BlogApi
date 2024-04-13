using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterApi.Core.Entities;

namespace TwitterApi.DAL.Configurations
{
    public class TopicConfiguration : IEntityTypeConfiguration<Topic>
    {
        public void Configure(EntityTypeBuilder<Topic> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(32)
                .IsRequired();
        }
    }
}
