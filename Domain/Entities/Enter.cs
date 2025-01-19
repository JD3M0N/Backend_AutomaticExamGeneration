using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Enter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("E_ID")]
        public int Id { get; set; }

        [ForeignKey("Professor")]
        [Column("P_ID")]
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        [ForeignKey("Question")]
        [Column("Q_ID")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
