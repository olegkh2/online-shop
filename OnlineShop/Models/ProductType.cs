using OnlineShop.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class ProductType : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Product type")]
        [Required(ErrorMessage = "Product type is required")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Product type must be between 3 and 30 chars")]
        public string Type { get; set; }

        //Relationships
        public List<Product> Products { get; set; }
    }
}
