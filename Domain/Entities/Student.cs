using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Student : User
    {
        [Column("E_Age")]
        public int Age { get; set; }

        [Column("Course")]
        public int Grade { get; set; }
    }
}
