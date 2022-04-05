using OnlineShop.Data.Base;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Services
{
    public class TypesService : EntityBaseRepository<ProductType>, ITypesService
    {
        public TypesService(AppDbContext context) : base(context)
        {
        }
    }
}
