using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class ProfessorExamReviewDto
    {
        public string ProfessorName { get; set; }
        public string AssignmentName { get; set; }
        public int ExamsReviewed { get; set; }
    }
}
