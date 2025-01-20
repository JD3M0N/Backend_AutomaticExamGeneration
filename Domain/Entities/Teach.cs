using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Teach
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Teach_ID")]
        public int Id { get; set; }

        [ForeignKey("Professor")]
        [Column("P_ID")]
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        [ForeignKey("Assignment")]
        [Column("A_ID")]
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
    }
}
