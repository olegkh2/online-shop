using OnlineShop.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Product : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 70 chars")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 100 chars")]
        public string Description { get; set; }

        [Display(Name = "Image URL")]
        [Required(ErrorMessage = "Image URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Size")]
        [StringLength(70, ErrorMessage = "Size must be less than 70 chars")]
        public string Size { get; set; }

        // Grams
        [Display(Name = "Weight")]
        public int Weight { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        //Relationships
        public List<Material_Product> Materials_Products { get; set; }

        public int TypeId { get; set; }
        [ForeignKey("TypeId")]
        public ProductType Type { get; set; }
    }
}
