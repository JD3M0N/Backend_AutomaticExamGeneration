using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Admin
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("AdminName")]
        public string Name { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("password")]
        public string Password { get; set; }

    }
}
