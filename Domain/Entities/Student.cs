using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ST_ID")]
        public int Id { get; set; }

        [Column("ST_Name")]
        public string Name { get; set; }

        [Column("ST_Email")]
        public string Email { get; set; }

        [Column("ST_Password")]
        public string Password { get; set; }

        [Column("ST_Age")]
        public int Age { get; set; }

        [Column("ST_Course")]
        public string Grade { get; set; }
    }
}
