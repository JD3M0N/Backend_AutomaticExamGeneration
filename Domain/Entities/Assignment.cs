using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Assignment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("A_ID")]
        public int Id { get; set; }

        [Column("A_Name")]
        public string Name { get; set; }

        [Column("Study_Program")]
        public string StudyProgram { get; set; }

        [ForeignKey("Professor")]
        [Column("U_ID")]
        public int ProfessorId { get; set; }

        public Professor Professor { get; set; }
    }
}
