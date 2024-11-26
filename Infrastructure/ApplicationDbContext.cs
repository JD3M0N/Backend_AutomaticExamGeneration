using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; } // Add this line

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure table names
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<User>().ToTable("User"); // Add this line
        }
    }
}
