using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBSC_LEARN.Data
{
    public class Video
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Descripton { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public DateTimeOffset Date { get; set; }

        public int Likes { get; set; }

        [Required]
        public Category Category { get; set; }

        public ICollection<Exam> Exams { get; set; }

    }
}
