using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Dtos
{
    public class CreateTopicDto
    {
        public string Name { get; set; }
        public int AssignmentId { get; set; }
    }

}
