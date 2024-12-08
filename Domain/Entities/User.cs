using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("U_ID")]
        public int Id { get; set; }

        [Column("U_Name")]
        public string Name { get; set; }

        [Column("Gmail")]
        public string Email { get; set; }

        [Column("Rol")]
        public string Rol { get; set; }

        [Column("Password")]
        public string Password { get; set; }
    }
}
