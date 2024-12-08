using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Professor : User
    {
        [Column("Speciality")]
        public string Speciality { get; set; }
    }
}
