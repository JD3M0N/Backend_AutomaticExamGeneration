using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Professor 
    {
        [Key]
        [Column("U_ID")]
        public int Id { get; set; }
        [Column("Speciality")]
        public string Speciality { get; set; }
    }
}
