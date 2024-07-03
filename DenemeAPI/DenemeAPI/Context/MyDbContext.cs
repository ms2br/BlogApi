using DenemeAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DenemeAPI.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
