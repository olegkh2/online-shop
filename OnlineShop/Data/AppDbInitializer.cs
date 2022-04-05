using OnlineShop.Data.Static;
using OnlineShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Types
                if (!context.Types.Any())
                {
                    context.Types.AddRange(new List<ProductType>()
                    {
                        new ProductType()
                        {
                            Type = "Accessory",
                        },
                        new ProductType()
                        {
                            Type = "Decor",
                        },
                        new ProductType()
                        {
                            Type = "Tableware",
                        },
                    });
                    context.SaveChanges();
                }
                
                //Materials
                if (!context.Materials.Any())
                {
                    context.Materials.AddRange(new List<Material>()
                    {
                        new Material()
                        {
                            MaterialName = "Turquoise",
                        },
                        new Material()
                        {
                            MaterialName = "Bronze",
                        },
                        new Material()
                        {
                            MaterialName = "Straw",
                        },
                        new Material()
                        {
                            MaterialName = "Viscose",
                        },
                        new Material()
                        {
                            MaterialName = "Wood",
                        },
                        new Material()
                        {
                            MaterialName = "Gypsum",
                        },
                        new Material()
                        {
                            MaterialName = "Clay",
                        },
                        new Material()
                        {
                            MaterialName = "Wax",
                        },
                        new Material()
                        {
                            MaterialName = "Cardboard",
                        },
                    });
                    context.SaveChanges();
                }
                
                //Products
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Name = "Medallion",
                            Description = "Turquoise medallion.",
                            ImageURL = "https://i.postimg.cc/VLdwsmfc/image.png",
                            Size = "The pendant is 3 cm long and 2 cm wide.",
                            Weight = 80,
                            Price = 12.50,
                            TypeId = 1,

                        },
                        new Product()
                        {
                            Name = "Bag",
                            Description = "Wicker bag.",
                            ImageURL = "https://i.postimg.cc/1RYxj2p7/image.png",
                            Size = "Dimensions 30 by 20 centimeters.",
                            Weight = 300,
                            Price = 5,
                            TypeId = 1,

                        },
                        new Product()
                        {
                            Name = "Grocery bag",
                            Description = "Convenient and roomy grocery bag.",
                            ImageURL = "https://i.postimg.cc/sgYNsNhr/image.png",
                            Size = "Dimensions 40 by 40 centimeters.",
                            Weight = 100,
                            Price = 3.40,
                            TypeId = 1,

                        },
                        new Product()
                        {
                            Name = "Angel figurine",
                            Description = "Wood carved figurine of an angel.",
                            ImageURL = "https://i.postimg.cc/3ry7Y3JQ/image.png",
                            Size = "Size 15 by 5 centimeters.",
                            Weight = 300,
                            Price = 10,
                            TypeId = 2,

                        },
                        new Product()
                        {
                            Name = "Torso sculpture of a girl",
                            Description = "Gypsum plaster figure of a girl's torso.",
                            ImageURL = "https://i.postimg.cc/bwg415NR/image.png",
                            Size = "Height - 30 centimeters, width - 15 centimeters.",
                            Weight = 500,
                            Price = 35,
                            TypeId = 2,

                        },
                        new Product()
                        {
                            Name = "Сup",
                            Description = "Creative clay cup with a capacity of 400 ml.",
                            ImageURL = "https://i.postimg.cc/YCdyvmbn/image.png",
                            Size = "Size 7 by 6 centimeters.",
                            Weight = 200,
                            Price = 5.50,
                            TypeId = 3,

                        },
                        new Product()
                        {
                            Name = "Candle",
                            Description = "Candle with the addition of cedar aromatic oils to the composition. Burning time 95 hours.",
                            ImageURL = "https://i.postimg.cc/vT70b14v/image.png",
                            Size = "Size 3 by 7 centimeters.",
                            Weight = 70,
                            Price = 1,
                            TypeId = 2,

                        },
                        new Product()
                        {
                            Name = "Jug",
                            Description = "Clay jug with a capacity of 1200 ml.",
                            ImageURL = "https://i.postimg.cc/2S92kNSg/image.png",
                            Size = "Size 9 by 20 centimeters.",
                            Weight = 300,
                            Price = 12,
                            TypeId = 3,

                        },
                        new Product()
                        {
                            Name = "Small house",
                            Description = "A decorative house that will decorate your home for the holiday.",
                            ImageURL = "https://i.postimg.cc/02cCn1Dr/image.png",
                            Size = "Height 25cm, width 15cm.",
                            Weight = 250,
                            Price = 10,
                            TypeId = 2,

                        },
                    });
                    context.SaveChanges();
                }
                                
                //Material_Product
                if (!context.Materials_Products.Any())
                {
                    context.Materials_Products.AddRange(new List<Material_Product>()
                    {
                        new Material_Product()
                        {
                            MaterialId = 1,
                            ProductId = 1
                        },
                        new Material_Product()
                        {
                            MaterialId = 2,
                            ProductId = 1
                        },
                        new Material_Product()
                        {
                            MaterialId = 3,
                            ProductId = 2
                        },
                        new Material_Product()
                        {
                            MaterialId = 4,
                            ProductId = 3
                        },
                        new Material_Product()
                        {
                            MaterialId = 5,
                            ProductId = 4
                        },
                        new Material_Product()
                        {
                            MaterialId = 6,
                            ProductId = 5
                        },
                        new Material_Product()
                        {
                            MaterialId = 7,
                            ProductId = 6
                        },
                        new Material_Product()
                        {
                            MaterialId = 8,
                            ProductId = 7
                        },
                        new Material_Product()
                        {
                            MaterialId = 7,
                            ProductId = 8
                        },
                        new Material_Product()
                        {
                            MaterialId = 9,
                            ProductId = 9
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));


                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                string adminUserEmail = "admin@admin.com";
                var adminUser = await userManager.FindByIdAsync(adminUserEmail);
                if(adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin@123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@user.com";
                var appUser = await userManager.FindByIdAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAppUser, "User@123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
