using OnlineShop.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Models
{
    public class Material : IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Material name")]
        [Required(ErrorMessage = "Material name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Material name must be between 3 and 50 chars")]
        public string MaterialName { get; set; }

        //Relationships
        public List<Material_Product> Materials_Products { get; set; }
    }
}
