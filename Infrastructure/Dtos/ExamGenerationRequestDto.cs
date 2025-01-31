using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class ExamGenerationRequestDto
    {
        public int ProfessorId { get; set; }
        public int AssignmentId { get; set; }
        public List<QuestionSelectionDto> Questions { get; set; }
    }
}
