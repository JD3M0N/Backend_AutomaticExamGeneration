using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class ResponseDto
    {
        public int StudentId { get; set; } // Foreign key to Student
        public int QuestionId { get; set; } // Foreign key to Question
        public int ExamId { get; set; } // Foreign key to Exam
        public string Answer { get; set; } // Student's answer
    }
}

