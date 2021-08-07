using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroShop1.Models
{
    public class ProductCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "A mininum of 2 characters needed.")]
        [MaxLength(200, ErrorMessage = "Woah there too many characters!")]
        public string Name { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "A mininum of 2 characters needed.")]
        [MaxLength(200, ErrorMessage = "Woah there too many characters!")]
        public string Desctription { get; set; }
        [MaxLength(200, ErrorMessage = "Woah there too many characters!")]
        public string Manufacturer { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Msrp { get; set; }
        [Required]
        public int ModelNumber { get; set;}

        [Required]
        public int CategoryId { get; set; }
    }
}
