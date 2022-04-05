using OnlineShop.Data.Base;
using OnlineShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Services
{
    public class MaterialsService : EntityBaseRepository<Material>, IMaterialsService
    {
        public MaterialsService(AppDbContext context) : base(context) {}

    }
}
