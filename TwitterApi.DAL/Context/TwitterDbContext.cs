using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TwitterApi.Core.Entities;
using TwitterApi.Core.Entities.Common;
using TwitterApi.Core.Entities.Identity;
using TwitterApi.Core.Enums;
namespace TwitterApi.DAL.Context
{
    public class TwitterDbContext : IdentityDbContext
    {
        public TwitterDbContext(DbContextOptions opt) : base(opt) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<FileEntity> Files { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var enties = ChangeTracker.Entries<BaseEntity>();
            foreach (var entity in enties)
            {
                if (entity.State == EntityState.Added)
                    entity.Entity.CreateTime = DateTime.UtcNow;
                else if (entity.State == EntityState.Modified)
                    entity.Entity.UpdateTime = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var builder = modelBuilder.Entity<IdentityUser>();
            builder.Ignore(x => x.PhoneNumberConfirmed);
            builder.Ignore(x => x.PhoneNumber);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
