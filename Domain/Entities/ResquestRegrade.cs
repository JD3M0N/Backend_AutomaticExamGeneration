using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class RequestRegrade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("RRG_ID")]
        public int Id { get; set; }

        [Column("P_ID")]
        public int ProfessorId { get; set; } // Foreign key to Professor
        public Professor Professor { get; set; } // Navigation property

        [Column("ST_ID")]
        public int StudentId { get; set; } // Foreign key to Student
        public Student Student { get; set; } // Navigation property

        [Column("Q_ID")]
        public int QuestionId { get; set; } // Foreign key to Question
        public Question Question { get; set; } // Navigation property

        [Column("X_ID")]
        public int ExamId { get; set; } // Foreign key to Exam
        public Exam Exam { get; set; } // Navigation property

        [Column("State")]
        public bool State { get; set; } // True if reviewed, False otherwise
    }
}
