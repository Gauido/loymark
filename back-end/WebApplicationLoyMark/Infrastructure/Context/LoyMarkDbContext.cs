using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class LoyMarkDbContext : DbContext
    {
        public LoyMarkDbContext(DbContextOptions<LoyMarkDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Activity>().ToTable("Activities");
        }

    }
}