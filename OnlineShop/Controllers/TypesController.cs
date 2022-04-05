using OnlineShop.Data;
using OnlineShop.Data.Services;
using OnlineShop.Models;
using Microsoft.AspNetCore.Mvc;
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
    public class TypesController : Controller
    {
        private readonly ITypesService _service;

        public TypesController(ITypesService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allTypes = await _service.GetAllAsync();
            return View(allTypes);
        }


        //GET: Types/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Type")] ProductType productType)
        {
            if (!ModelState.IsValid) return View(productType);
            await _service.AddAsync(productType);
            return RedirectToAction(nameof(Index));
        }
                
        //GET: types/edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var typeDetails = await _service.GetByIdAsync(id);
            if (typeDetails == null) return View("NotFound");
            return View(typeDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Type")] ProductType productType)
        {
            if (!ModelState.IsValid) return View(productType);
            await _service.UpdateAsync(id, productType);
            return RedirectToAction(nameof(Index));
        }

        //GET: types/delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var typesDetails = await _service.GetByIdAsync(id);
            if (typesDetails == null) return View("NotFound");
            return View(typesDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var typesDetails = await _service.GetByIdAsync(id);
            if (typesDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
