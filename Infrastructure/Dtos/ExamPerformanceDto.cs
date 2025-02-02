using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class ExamPerformanceDto
    {
        public int ExamId { get; set; }
        public string QuestionText { get; set; }
        public int Difficulty { get; set; }
        public int TotalResponses { get; set; }
        public int CorrectResponses { get; set; }
        public int IncorrectResponses { get; set; }
        public double AccuracyRate { get; set; } // Porcentaje de respuestas correctas
    }
}
