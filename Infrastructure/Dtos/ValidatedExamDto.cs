using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class ValidatedExamDto
    {
        public int ExamId { get; set; }
        public string AssignmentName { get; set; }
        public DateTime ValidationDate { get; set; }
        public string Observations { get; set; }
    }
}
