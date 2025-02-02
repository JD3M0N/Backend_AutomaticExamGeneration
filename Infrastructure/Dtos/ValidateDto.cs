using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class ValidateDto
    {
        public int ExamId { get; set; }
        public int ProfessorId { get; set; }
        public string Observations { get; set; }
        public DateTime ValidationDate { get; set; }
    }
}
