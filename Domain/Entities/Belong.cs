using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Belong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Belong_ID")]
        public int Id { get; set; }

        [ForeignKey("Question")]
        [Column("Q_ID")]
        public int QuestionId { get; set; }
        //public Question Question { get; set; }

        [ForeignKey("Exam")]
        [Column("X_ID")]
        public int ExamId { get; set; }


        // Navigation Properties
        public Question Question { get; set; }
        public Exam Exam { get; set; }
    }
}
