using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Professor 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("P_ID")]
        public int Id { get; set; }

        [Column("P_Name")]
        public string Name { get; set; }

        [Column("P_Email")]
        public string Email { get; set; }

        [Column("P_Password")]
        public string Password { get; set; }

        [Column("P_Specialization")]
        public string Specialization { get; set; }
        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
        public ICollection<Enter> Enters { get; set; } = new List<Enter>();
    }
}
