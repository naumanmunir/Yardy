
using Microsoft.EntityFrameworkCore;

namespace Yardy.Models
{
    public class YardyDbContext : DbContext
    {
        public DbSet<YardSale> YardSales { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Role> Role { get; set; }

        public YardyDbContext()
        {

        }

        public YardyDbContext(DbContextOptions<YardyDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=nauman\sqlexpress;Database=Yardy;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
