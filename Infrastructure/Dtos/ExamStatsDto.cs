using Domain.Entities;
using System;

namespace Infrastructure.Dtos
{
    public class ExamStatsDto
    {
        public int ExamId { get; set; }
        public string ProfessorName { get; set; }
        public DateTime CreationDate { get; set; }
        public int TotalQuestions { get; set; }
        public int Difficulty { get; set; }
        public int? TopicLimit { get; set; }
    }
}
