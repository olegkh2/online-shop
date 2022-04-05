using OnlineShop.Data.Base;
using OnlineShop.Data.ViewModels;
using OnlineShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data.Services
{
    public class ProductsService : EntityBaseRepository<Product>, IProductsService
    {
        private readonly AppDbContext _context;
        public ProductsService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewProductAsync(NewProductVM data)
        {
            var newProduct = new Product()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                Size = data.Size,
                Weight = data.Weight,
                TypeId = data.TypeId,
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            //Add Materials_Products
            foreach (var materialId in data.MaterialIds)
            {
                var newMaterialProduct = new Material_Product()
                {
                    ProductId = newProduct.Id,
                    MaterialId = materialId
                };
                await _context.Materials_Products.AddAsync(newMaterialProduct);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var productDetails = await _context.Products
                .Include(t => t.Type)
                .Include(mp => mp.Materials_Products).ThenInclude(m => m.Material)
                .FirstOrDefaultAsync(n => n.Id == id);

            return productDetails;
        }

        public async Task<ProductDropdownsVM> GetProductDropdownsValues()
        {
            var response = new ProductDropdownsVM()
            {
                Types = await _context.Types.OrderBy(n => n.Type).ToListAsync(),
                Materials = await _context.Materials.OrderBy(n => n.MaterialName).ToListAsync(),
            };

            return response;
        }

        public async Task UpdateProductAsync(NewProductVM data)
        {
            var dbProduct = await _context.Products.FirstOrDefaultAsync(n => n.Id == data.Id);

            if(dbProduct != null)
            {
                dbProduct.Name = data.Name;
                dbProduct.Description = data.Description;
                dbProduct.Price = data.Price;
                dbProduct.ImageURL = data.ImageURL;
                dbProduct.Size = data.Size;
                dbProduct.Weight = data.Weight;
                dbProduct.TypeId = data.TypeId;
                await _context.SaveChangesAsync();
            }

            //Remove existing materials
            var existingMaterialsDb = _context.Materials_Products.Where(n => n.ProductId == data.Id).ToList();
            _context.Materials_Products.RemoveRange(existingMaterialsDb);
            await _context.SaveChangesAsync();

            //Add Materials_Products
            foreach (var materialId in data.MaterialIds)
            {
                var newMaterialProduct = new Material_Product()
                {
                    ProductId = data.Id,
                    MaterialId = materialId
                };
                await _context.Materials_Products.AddAsync(newMaterialProduct);
            }
            await _context.SaveChangesAsync();
        }
    }
}
