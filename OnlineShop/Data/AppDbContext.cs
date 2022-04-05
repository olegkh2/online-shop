using OnlineShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Material_Product>().HasKey(mp => new
            {
                mp.MaterialId,
                mp.ProductId
            });
            modelBuilder.Entity<Material_Product>().HasOne(m => m.Material).WithMany(mp => mp.Materials_Products).
                HasForeignKey(m => m.MaterialId);
            modelBuilder.Entity<Material_Product>().HasOne(p => p.Product).WithMany(mp => mp.Materials_Products).
                HasForeignKey(p => p.ProductId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProductType> Types { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Material_Product> Materials_Products { get; set; }
        public DbSet<Product> Products { get; set; }

        //Orders related tables
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
