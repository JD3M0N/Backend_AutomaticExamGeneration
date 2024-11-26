using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Student
    {
        [Key]
        [Column("St_ID")]
        public int Id { get; set; }

        [Column("St_Name")]
        public string Name { get; set; }

        [Column("St_Age")]
        public int Age { get; set; }

        [Column("St_Grade")]
        public int Grade { get; set; }
    }
}
