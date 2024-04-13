using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterApi.Core.Entities.Identity;

namespace TwitterApi.DAL.Configurations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(x => x.BirthDate)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.UserName)
                .IsRequired()
                .HasMaxLength(32);

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(x => x.ImgUrl)
                .IsRequired(false);
        }
    }
}
