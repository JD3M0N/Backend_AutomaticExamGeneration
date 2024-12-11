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
        public DbSet<Topic> Topic { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Assignment> Assignment { get; set; }
        public DbSet<Exam> Exam { get; set; }
        public DbSet<Response> Response { get; set; }

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

            // Configurar la tabla para Topic
            modelBuilder.Entity<Topic>()
                .ToTable("Topic");

            // Configurar la tabla para Question
            modelBuilder.Entity<Question>()
                .ToTable("Question");

            // Configurar la relación entre Question y Topic
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Topic)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TopicId);

            // Configurar la tabla para Assignment
            modelBuilder.Entity<Assignment>()
                .ToTable("Assignment");

            // Configurar la relación entre Assignment y Professor
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Professor)
                .WithOne()
                .HasForeignKey<Assignment>(a => a.ProfessorId);

            // Configurar la tabla para Exam
            modelBuilder.Entity<Exam>()
                .ToTable("Exam");

            // Configurar la relación entre Exam y Assignment
            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Assignment)
                .WithMany()
                .HasForeignKey(e => e.AssignmentId);

            // Configurar la relación entre Exam y Professor
            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Professor)
                .WithMany()
                .HasForeignKey(e => e.ProfessorId);

            // Configurar la tabla para Response
            modelBuilder.Entity<Response>()
                .ToTable("Response");

            // Configurar la relación entre Response y Student
            modelBuilder.Entity<Response>()
                .HasKey(r => new { r.StudentId, r.ExamId });

            modelBuilder.Entity<Response>()
                .HasOne(r => r.Student)
                .WithMany()
                .HasForeignKey(r => r.StudentId);

            modelBuilder.Entity<Response>()
                .HasOne(r => r.Exam)
                .WithMany()
                .HasForeignKey(r => r.ExamId);
        }
    }
}
