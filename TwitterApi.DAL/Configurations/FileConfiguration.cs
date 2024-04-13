using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterApi.Core.Entities;

namespace TwitterApi.DAL.Configurations
{
    public class FileConfiguration : IEntityTypeConfiguration<FileEntity>
    {
        public void Configure(EntityTypeBuilder<FileEntity> builder)
        {
            builder.Property(x => x.Name)
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(x => x.ContentType)
                .IsRequired();

            builder.Property(x => x.Path)
                .IsRequired();
        }
    }
}
