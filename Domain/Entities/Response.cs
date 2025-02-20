﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Response
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("R_ID")]
        public int Id { get; set; }

        [Column("ST_ID")]
        public int StudentId { get; set; } // Foreign key to Student
        public Student Student { get; set; } // Navigation property

        [Column("Q_ID")]
        public int QuestionId { get; set; } // Foreign key to Question
        public Question Question { get; set; } // Navigation property

        [Column("X_ID")]
        public int ExamId { get; set; } // Foreign key to Exam
        public Exam Exam { get; set; } // Navigation property

        [Column("Answer")]
        public string Answer { get; set; } // Student's answer
    }
}
