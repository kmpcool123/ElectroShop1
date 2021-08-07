using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroShop1.Models
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Manufacturer Suggested Retail Price")]
        public decimal Msrp { get; set; }
        [Display(Name = "Model Number")]
        public int ModelNumber { get; set; }

        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name="Modified")]
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
