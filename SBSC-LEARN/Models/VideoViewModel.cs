using Microsoft.AspNetCore.Http;
using SBSC_LEARN.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBSC_LEARN.Models
{
    public class VideoViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Descripton { get; set; }

        public IFormFile Video { get; set; }


        public int Likes { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
    }
}
