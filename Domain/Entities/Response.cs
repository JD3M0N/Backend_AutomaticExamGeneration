using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Response
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Exam")]
        public int ExamId { get; set; }

        [Column("Response_Date")]
        public DateTime ResponseDate { get; set; }

        [Column("Response_Text")]
        public string ResponseText { get; set; }

        public Student Student { get; set; }
        public Exam Exam { get; set; }
    }
}

