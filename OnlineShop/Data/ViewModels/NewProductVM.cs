using OnlineShop.Data;
using OnlineShop.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class NewProductVM
    {
        public int Id { get; set; }

        [Display(Name = "Product name")]
        [Required(ErrorMessage = "Product name is required")]
        [StringLength(70, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 70 chars")]
        public string Name { get; set; }

        [Display(Name = "Product description")]
        [Required(ErrorMessage = "Description is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Description must be between 3 and 100 chars")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Produce photo URL")]
        [Required(ErrorMessage = "Product photo URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Size")]
        [StringLength(70, ErrorMessage = "Size must be less than 70 chars")]
        public string Size { get; set; }

        // Grams
        [Display(Name = "Weight")]
        public int Weight { get; set; }


        //Relationships
        [Display(Name = "Select material(s)")]
        public List<int> MaterialIds { get; set; }

        [Display(Name = "Select a type")]
        public int TypeId { get; set; }
    }
}
