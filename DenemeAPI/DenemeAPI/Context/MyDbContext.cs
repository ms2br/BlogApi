using DenemeAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DenemeAPI.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ModelOne> ModelOnes { get; set; }
        public DbSet<ModelTwo> ModelTwos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
