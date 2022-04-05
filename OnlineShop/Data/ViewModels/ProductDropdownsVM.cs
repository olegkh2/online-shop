
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.ViewModels
{
    public class ProductDropdownsVM
    {
        public ProductDropdownsVM()
        {
            Types = new List<ProductType>();
            Materials = new List<Material>();
        }

        public List<ProductType> Types { get; set; }
        public List<Material> Materials { get; set; }
    }
}
