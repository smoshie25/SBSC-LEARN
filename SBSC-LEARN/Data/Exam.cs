using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBSC_LEARN.Data
{
    public class Exam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public User User { get; set; }
        public Video Video { get; set; }
        public DateTimeOffset Date { get; set; }
        [Required]
        public int Score { get; set; }
    }
}
