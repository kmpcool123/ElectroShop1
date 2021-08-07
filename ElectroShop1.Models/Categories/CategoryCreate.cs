using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectroShop1.Models.Categories
{
    public class CategoryCreate
    {
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        [Display(Name = "Short description")]
        public string Description { get; set; }
    }
}
