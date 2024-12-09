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
        [Column("U_ID")]
        public int ProfessorId { get; set; }

        [Column("PPT")]
        public string PPT { get; set; }

        [Column("CT")]
        public string CT { get; set; }

        [Column("CTP")]
        public string CTP { get; set; }

        [Column("Creation_Date")]
        public DateTime Date { get; set; }

        [Column("Status")]
        public string Status { get; set; }

        public Assignment Assignment { get; set; }
        public Professor Professor { get; set; }
    }
}
