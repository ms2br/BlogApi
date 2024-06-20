using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterApi.Core.Enums;

namespace TwitterApi.DAL.Configurations
{
    public class IdentityRoleConfiguration :
        IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            foreach (string role in Enum.GetNames(typeof(Roles)))
            {
                builder.HasData(new IdentityRole { Name = role, NormalizedName = role.ToUpper() });
            }
        }
    }
}
