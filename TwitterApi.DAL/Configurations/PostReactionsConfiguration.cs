using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Core.Entities;

namespace TwitterApi.DAL.Configurations
{
    public class PostReactionsConfiguration : IEntityTypeConfiguration<PostReaction>
    {
        public void Configure(EntityTypeBuilder<PostReaction> builder)
        {
            builder.Ignore(x => x.Id).Ignore(x => x.IsDeleted);

            builder.HasKey(x => new { x.PostId, x.AppUserId });

            builder.HasOne(x => x.AppUser)
                .WithMany(x => x.PostReactions)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Post)
                .WithMany(x => x.PostReactions)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
