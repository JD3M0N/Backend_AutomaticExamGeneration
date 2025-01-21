using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Own
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Own_ID")]
        public int Id { get; set; }

        [ForeignKey("Assignment")]
        [Column("A_ID")]
        public int AssignmentId { get; set; }

        [ForeignKey("Topic")]
        [Column("T_ID")]
        public int TopicId { get; set; }

        public Assignment Assignment { get; set; }
        public Topic Topic { get; set; }
    }
}
