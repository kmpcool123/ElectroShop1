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
   public class Category
    {
        
            []
            // Primary Key
            [Key]
            public int CategoryID { get; set; }
            [Required]
            [DisplayName("Category")]
            public string CategoryName { get; set; }
            public string Description { get; set; }

            // Foreign Key?
            public virtual ICollection<Product> Products { get; set; }

            public DateTimeOffset? CreatedUtc { get; set; }
            public DateTimeOffset? Modified { get; set; }



    }
}
