using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroShop1.Models.Categories
{
    public class CategoryDetail
    {
        
        public int CategoryId { get; set; }
        
        [Display(Name = "Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Created Time")]
        public DateTimeOffset CreatedUtc { get; set; }

        [Display(Name = "Modified Time")]
        public DateTimeOffset ModifiedUtc { get; set; }
    }
}
