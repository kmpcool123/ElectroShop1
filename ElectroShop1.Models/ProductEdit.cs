using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroShop1.Models
{
    public class ProductEdit
    {
        public int ProductId { get; set; }
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this fiels.")]
        public string Name { get; set; }
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this fiels.")]
        public string Description { get; set; }
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this fiels.")]
        public string Manufacturer { get; set; }

        public decimal Price { get; set; }
        [Display(Name = "Manufacturer Suggested Retail Price")]
        public decimal Msrp { get; set; }
        [Display(Name = "Model Number")]
        public int ModelNumber { get; set; }
    }
}
