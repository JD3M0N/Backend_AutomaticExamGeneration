using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class QuestionDto
    {
        public int Difficulty { get; set; }
        public string Type { get; set; }
        public string QuestionText { get; set; }
        public int TopicId { get; set; }
    }
}
