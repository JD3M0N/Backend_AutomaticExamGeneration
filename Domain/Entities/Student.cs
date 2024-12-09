using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Student
    {
        [Key]
        [Column("U_ID")]
        public int Id { get; set; }

        [Column("E_Age")]
        public int Age { get; set; }

        [Column("Course")]
        public string Grade { get; set; }
    }
}
