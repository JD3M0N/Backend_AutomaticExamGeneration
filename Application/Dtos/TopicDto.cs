using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class TopicDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AssignmentId { get; set; }
        public string AssignmentName { get; set; }
    }
}
