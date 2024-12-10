using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Response
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Response_ID")]
        public int Id { get; set; }

        [ForeignKey("Student")]
        [Column("ST_ID")]
        public int StudentId { get; set; }

        [ForeignKey("Exam")]
        [Column("X_ID")]
        public int ExamId { get; set; }
    }
}
