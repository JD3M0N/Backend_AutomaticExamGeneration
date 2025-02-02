using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class ExamComparisonDto
    {
        public string AssignmentName { get; set; }
        public Dictionary<string, double> TopicDistribution { get; set; } // % de preguntas por tema
        public double AverageDifficulty { get; set; } // Dificultad promedio de los exámenes
    }
}
