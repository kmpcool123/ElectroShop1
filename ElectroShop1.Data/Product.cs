using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroShop1.Data
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        //[Required]
        public Guid OwnerId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "A mininum of 2 characters needed.")]
        [MaxLength(200, ErrorMessage = "Woah there too many characters!")]
        public string Name { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "A mininum of 2 characters needed.")]
        [MaxLength(800, ErrorMessage = "Woah there too many characters!")]
        public string Description { get; set; }
        public string Manufacturer { get; set; }
        [Required]

        public decimal Price { get; set; }

        public decimal Msrp { get; set; }

        public int ModelNumber { get; set; }
        [ForeignKey(nameof(Category))]

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        public DateTimeOffset CreatedUtc { get; set; }

        public DateTimeOffset? Modified { get; set; }
    }
}
