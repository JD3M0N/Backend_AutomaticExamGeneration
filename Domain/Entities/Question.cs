using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Q_ID")]
        public int Id { get; set; }

        [Column("Difficulty")]
        public int Difficulty { get; set; }

        [Column("Type")]
        public string Type { get; set; }

        [Column("Question_Text")]
        public string QuestionText { get; set; }

        [ForeignKey("Topic")]
        [Column("T_ID")]
        public int TopicId { get; set; }
        public Topic Topic { get; set; }

        public ICollection<Exam> Exams { get; set; } = new List<Exam>();
        public ICollection<Belong> Belongs { get; set; } = new List<Belong>();
        public ICollection<Enter> Enters { get; set; } = new List<Enter>();
    }
}
