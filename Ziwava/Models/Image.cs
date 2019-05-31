using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ziwava.Models
{
    public class Image
    {
        [Required]
        public int id { get; set; }
        [Required]
        public int indawoId { get; set; }
        [Required]
        public string imgPath { get; set; }
        public HttpPostedFileBase imageUpload { get; set; }
    }
}