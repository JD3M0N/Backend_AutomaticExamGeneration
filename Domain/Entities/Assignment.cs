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
        [Column("P_ID")]
        public int ProfessorId { get; set; }

        public Professor Professor { get; set; }

        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
        public ICollection<Enroll> Enrolls { get; set; } = new List<Enroll>();
        public ICollection<Teach> Teaches { get; set; } = new List<Teach>();
        public ICollection<Topic> Topics { get; set; } = new List<Topic>();
    }

}
