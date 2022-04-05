using OnlineShop.Data;
using OnlineShop.Data.Services;
using OnlineShop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using OnlineShop.Data.Static;

namespace OnlineShop.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MaterialsController : Controller
    {
        private readonly IMaterialsService _service;

        public MaterialsController(IMaterialsService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allMaterials = await _service.GetAllAsync();
            return View(allMaterials);
        }

        //Get: Materials/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("MaterialName")] Material material)
        {
            if (!ModelState.IsValid)
            {
                return View(material);
            }
            await _service.AddAsync(material);
            return RedirectToAction(nameof(Index));
        }

        //Get: Materials/Edit/Id
        public async Task<IActionResult> Edit(int id)
        {
            var materialDetails = await _service.GetByIdAsync(id);
            if (materialDetails == null) return View("NotFound");
            return View(materialDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("MaterialName")] Material material)
        {
            if (!ModelState.IsValid)
            {
                return View(material);
            }
            await _service.UpdateAsync(id, material);
            return RedirectToAction(nameof(Index));
        }

        //Get: Materials/Delete/Id
        public async Task<IActionResult> Delete(int id)
        {
            var materialDetails = await _service.GetByIdAsync(id);
            if (materialDetails == null) return View("NotFound");
            return View(materialDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialDetails = await _service.GetByIdAsync(id);
            if (materialDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
