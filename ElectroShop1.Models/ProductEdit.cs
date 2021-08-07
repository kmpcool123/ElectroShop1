using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroShop1.Models
{
    public class ProductEdit
    {
        public int ProductId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacturer { get; set; }

        public decimal Price { get; set; }

        public decimal Msrp { get; set; }

        public int ModelNumber { get; set; }
    }
}
