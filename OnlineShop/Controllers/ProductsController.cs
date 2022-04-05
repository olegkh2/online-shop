using OnlineShop.Data;
using OnlineShop.Data.Services;
using OnlineShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Data.Static;

namespace OnlineShop.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductsController : Controller
    {
        private readonly IProductsService _service;

        public ProductsController(IProductsService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducts = await _service.GetAllAsync(n => n.Type);
            return View(allProducts);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _service.GetAllAsync(n => n.Type);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filtredResult = allProducts.Where(n => n.Name.Contains(searchString) 
                    || n.Description.Contains(searchString)
                    || n.Type.Type.Contains(searchString)).ToList();
                return View("Index", filtredResult);
            }

            return View("Index", allProducts);
        }

        //GET: Product/Details/Id
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var productDetail = await _service.GetProductByIdAsync(id);
            return View(productDetail);
        }

        //GET: Product/Create
        public async Task<IActionResult> Create()
        {
            var productDropdownsData = await _service.GetProductDropdownsValues();

            ViewBag.Types = new SelectList(productDropdownsData.Types, "Id", "Type");
            ViewBag.Materials = new SelectList(productDropdownsData.Materials, "Id", "MaterialName");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM product)
        {
            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetProductDropdownsValues();

                ViewBag.Types = new SelectList(productDropdownsData.Types, "Id", "Type");
                ViewBag.Materials = new SelectList(productDropdownsData.Materials, "Id", "MaterialName");

                return View(product);
            }

            await _service.AddNewProductAsync(product);
            return RedirectToAction(nameof(Index));
        }


        //GET: Products/Edit/Id
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _service.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            var response = new NewProductVM()
            {
                Id = productDetails.Id,
                Name = productDetails.Name,
                Description = productDetails.Description,
                Price = productDetails.Price,
                ImageURL = productDetails.ImageURL,
                Size = productDetails.Size,
                Weight = productDetails.Weight,
                TypeId = productDetails.TypeId,
                MaterialIds = productDetails.Materials_Products.Select(n => n.MaterialId).ToList(),
            };

            var productDropdownsData = await _service.GetProductDropdownsValues();
            ViewBag.Types = new SelectList(productDropdownsData.Types, "Id", "Type");
            ViewBag.Materials = new SelectList(productDropdownsData.Materials, "Id", "MaterialName");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM product)
        {
            if (id != product.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _service.GetProductDropdownsValues();

                ViewBag.Types = new SelectList(productDropdownsData.Types, "Id", "Type");
                ViewBag.Materials = new SelectList(productDropdownsData.Materials, "Id", "MaterialName");

                return View(product);
            }

            await _service.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
