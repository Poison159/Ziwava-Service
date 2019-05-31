using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace Ziwava.Models
{
    public class Indawo
    {
        public Indawo()
        {
            images = new List<Image>();
            imgPath = "~/Content/user.png";
            distance = 0;
            geoLocation = null;
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
        [NotMapped]
        public HttpPostedFileBase imageUpload { get; set; }
        [NotMapped]
        public double distance { get; set; }
        [NotMapped]
        public DbGeography geoLocation { get; set; }
    }
}