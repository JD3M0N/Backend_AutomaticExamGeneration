using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Usar estrategia TPT
            modelBuilder.Entity<User>().UseTptMappingStrategy();

            // Configurar la tabla para User
            modelBuilder.Entity<User>()
                .ToTable("User");

            // Configurar la tabla para Student
            modelBuilder.Entity<Student>()
                .ToTable("Student");

            // Configurar columnas específicas de Student
            modelBuilder.Entity<Student>()
                .Property(s => s.Age)
                .HasColumnName("E_Age");

            modelBuilder.Entity<Student>()
                .Property(s => s.Grade)
                .HasColumnName("Course");

            // Configurar Admin y Professor de manera similar si es necesario
        }

    }
}
