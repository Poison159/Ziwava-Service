using System.ComponentModel.DataAnnotations;

namespace Ziwava.Models
{
    public class Drink
    {
        public int id { get; set; }
        [Required]
        public int indawoId { get; set; }
        [Required]
        public string name { get; set; }
    }
}