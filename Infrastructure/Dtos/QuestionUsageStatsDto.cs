using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
        public class QuestionUsageStatsDto
        {
            public int QuestionId { get; set; }
            public string QuestionText { get; set; }
            public int Difficulty { get; set; }
            public string TopicName { get; set; }
            public int UsageCount { get; set; }
        }
}
