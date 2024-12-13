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
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public DateTime Date { get; set; }
        public string Solution { get; set; }
    }
}
