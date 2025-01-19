using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Enroll
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("E_ID")]
        public int Id { get; set; }

        [ForeignKey("Student")]
        [Column("S_ID")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Assignment")]
        [Column("A_ID")]
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }
    }
}
