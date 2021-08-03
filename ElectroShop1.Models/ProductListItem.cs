using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroShop1.Models
{
    public class ProductListItem
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

       
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
