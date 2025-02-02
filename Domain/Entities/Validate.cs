using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Validate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("V_ID")]
        public int Id { get; set; } // V_ID

        [ForeignKey("Exam")]
        [Column("X_ID")]
        public int ExamId { get; set; } // X_ID

        [ForeignKey("Professor")]
        [Column("P_ID")]
        public int ProfessorId { get; set; } // P_ID

        [Column("Observations")]
        public string Observations { get; set; } // Comentarios sobre la validación

        [Column("V_Date")]
        public DateTime ValidationDate { get; set; } // = DateTime.UtcNow; // V_Date

        [Column("V_State")]
        public bool ValidationState { get; set; } = false; // V_State: 1 = Validated, 0 = Not Validated

        public Exam Exam { get; set; } // Relación con Exam
        public Professor Professor { get; set; } // Relación con Professor
    }
}
