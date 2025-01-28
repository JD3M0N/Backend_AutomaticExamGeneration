using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Exam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("X_ID")]
        public int Id { get; set; }

        [ForeignKey("Assignment")]
        [Column("A_ID")]
        public int AssignmentId { get; set; }

        [ForeignKey("Professor")]
        [Column("P_ID")]
        public int ProfessorId { get; set; }

        [Column("Creation_Date")]
        public DateTime Date { get; set; }

        [Column("Total_Questions")]
        public int TotalQuestions { get; set; }

        [Column("Difficulty")]
        public int Difficulty { get; set; }

        [Column("Topic_Limit")]
        public int? TopicLimit { get; set; }

        public Assignment Assignment { get; set; }
        public Professor Professor { get; set; }
        public ICollection<Belong> Belongs { get; set; } = new List<Belong>();
    }
}
