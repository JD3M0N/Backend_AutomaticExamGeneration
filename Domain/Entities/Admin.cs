using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Admin_ID")]
        public int Id { get; set; }

        [Column("Admin_Name")]
        public string Name { get; set; }

        [Column("Admin_Email")]
        public string Email { get; set; }

        [Column("Admin_Password")]
        public string Password { get; set; }
    }
}
