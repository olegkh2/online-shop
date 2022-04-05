using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Material_Product
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
