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

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Response> Response { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la tabla para Student
            modelBuilder.Entity<Student>()
                .ToTable("Student");

            // Configurar la tabla para Topic
            modelBuilder.Entity<Topic>()
                .ToTable("Topic");

            // Configurar la tabla para Question
            modelBuilder.Entity<Question>()
                .ToTable("Question");
            // Configurar la tabla para Assignment
            modelBuilder.Entity<Assignment>()
                .ToTable("Assignment");

            // Configurar la tabla para Exam
            modelBuilder.Entity<Exam>()
                .ToTable("Exam");

            // Configurar la tabla para Response
            modelBuilder.Entity<Response>()
                .ToTable("Response");

            // Configurar la relación entre Question y Topic
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Topic)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TopicId);

            // Configurar la relación entre Assignment y Professor
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Professor)
                .WithOne()
                .HasForeignKey<Assignment>(a => a.ProfessorId);

            // Configurar la relación entre Exam y Assignment
            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Assignment)
                .WithMany()
                .HasForeignKey(e => e.AssignmentId);

            // Configurar la relación entre Exam y Professor
            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Professor)
                .WithMany(p => p.Exams)
                .HasForeignKey(e => e.ProfessorId);
        }
    }
}
