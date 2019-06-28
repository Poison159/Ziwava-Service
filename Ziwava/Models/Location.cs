using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ziwava.Models
{
    public class Location
    {
        public Location() {
            images = new List<Image>();
            imgPath = "~/Content/user.png";
        }
        [Required]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string lat { get; set; }
        [Required]
        public string lon { get; set; }
        [Required]
        public string imgPath { get; set; }
        public List<Image> images { get; set; }

    }
}