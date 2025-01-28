using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Diagnostics;

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
        public DbSet<Belong> Belong { get; set; }
        public DbSet<Enroll> Enroll { get; set; }
        public DbSet<Enter> Enter { get; set; }
        public DbSet<Teach> Teach { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Regrade> Regrades { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configuring the table for Student
            modelBuilder.Entity<Student>()
                .ToTable("Student");

            // Configuring the table for Professor
            modelBuilder.Entity<Topic>()
                .ToTable("Topic");

            // Configuring the table for Question
            modelBuilder.Entity<Question>()
                .ToTable("Question");

            // Configuring the table for Assignment
            modelBuilder.Entity<Assignment>()
                .ToTable("Assignment");

            // Configuring the table for Exam
            modelBuilder.Entity<Exam>()
                .ToTable("Exam");

            // Configuring the table for Response
            modelBuilder.Entity<Response>()
                .ToTable("Response");

            // Configuring the table for Belong
            modelBuilder.Entity<Belong>()
                .ToTable("Belong");

            // Configuring the table for Enroll
            modelBuilder.Entity<Enroll>()
                .ToTable("Enroll");

            // Configuring the table for Enter
            modelBuilder.Entity<Enter>()
                .ToTable("Enter");

            // Configuring the table for Teach
            modelBuilder.Entity<Teach>()
                .ToTable("Teach");

            // Configuring the table for Grade
            modelBuilder.Entity<Grade>()
                .ToTable("Grade");

            // Configuring the table for Regrade
            modelBuilder.Entity<Regrade>()
                .ToTable("Regrade");

            // Configuring the table for Topic
            // If an assignment is deleted, all its topics are deleted. Topic is weak entity of assigmnet
            modelBuilder.Entity<Topic>()
                .ToTable("Topic")
                .HasOne(t => t.Assignment)
                .WithMany(a => a.Topics)
                .HasForeignKey(t => t.AssignmentId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configuring the relationship between Question and Topic
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Topic)
                .WithMany(t => t.Questions)
                .HasForeignKey(q => q.TopicId);

            // Configuring the relationship between Assignment and Professor
            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Professor)
                .WithOne()
                .HasForeignKey<Assignment>(a => a.ProfessorId);

            // Configuring the relationship between Exam and Assignment
            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Assignment)
                .WithMany(a => a.Exams)
                .HasForeignKey(e => e.AssignmentId);

            // Configuring the relationship between Exam and Professor
            modelBuilder.Entity<Exam>()
                .HasOne(e => e.Professor)
                .WithMany(p => p.Exams)
                .HasForeignKey(e => e.ProfessorId);

            // Configurar la relación many-to-many entre Question y Exam usando Belong
            modelBuilder.Entity<Belong>()
                .HasOne(b => b.Question)
                .WithMany(q => q.Belongs)
                .HasForeignKey(b => b.QuestionId);

            modelBuilder.Entity<Belong>()
                .HasOne(b => b.Exam)
                .WithMany(e => e.Belongs)
                .HasForeignKey(b => b.ExamId);

            // Configuring the many-to-many relationship between Student and Assignment using Enroll
            modelBuilder.Entity<Enroll>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrolls)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enroll>()
                .HasOne(e => e.Assignment)
                .WithMany(a => a.Enrolls)
                .HasForeignKey(e => e.AssignmentId);

            // Configuring the relationship between Professor and Question using Enter
            modelBuilder.Entity<Enter>()
                .HasOne(e => e.Professor)
                .WithMany(p => p.Enters)
                .HasForeignKey(e => e.ProfessorId);

            modelBuilder.Entity<Enter>()
                .HasOne(e => e.Question)
                .WithMany(q => q.Enters)
                .HasForeignKey(e => e.QuestionId);

        }
    }
}
