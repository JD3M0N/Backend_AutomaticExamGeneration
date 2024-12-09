using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Dtos
{
    public class StudentDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Age { get; set; }
        public string Grade { get; set; }
    }
}
