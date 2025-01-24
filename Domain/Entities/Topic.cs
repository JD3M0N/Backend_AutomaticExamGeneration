using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("T_ID")]
        public int Id { get; set; }

        [Column("T_Name")]
        public string Name { get; set; }

        [ForeignKey("Assignment")]
        [Column("A_ID")]
        public int AssignmentId { get; set; }

        public Assignment Assignment { get; set; }
        public ICollection<Question> Questions { get; set; } = new List<Question>();
    }
}
