using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Admin
    {
        [Key]
        [Column("U_ID")]
        public int Id { get; set; }
    }
}
