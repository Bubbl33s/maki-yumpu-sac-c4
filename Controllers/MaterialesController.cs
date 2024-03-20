using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakiYumpuSAC.Models;
using MakiYumpuSAC.Resources;
using Microsoft.AspNetCore.Authorization;

namespace MakiYumpuSAC.Controllers
{
    [Authorize]
    public class MaterialesController : Controller
    {
        private readonly MakiYumpuSacContext _context;

        public MaterialesController(MakiYumpuSacContext context)
        {
            _context = context;
        }

        // GET: Materiales
        public async Task<IActionResult> Index()
        {
            return View(
                await _context.Materials
                .Include(m => m.IdMaterialBaseNavigation)
                .Where(m => m.Activo &&
                m.IdMaterialBaseNavigation.Activo)
                .ToListAsync()
                );
        }

        // GET: Materiales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materials
                .Include(m => m.IdMaterialBaseNavigation)
                .FirstOrDefaultAsync(m => m.IdMaterial == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // GET: Materiales/Create
        public IActionResult Create()
        {
            LoadData();

            return View();
        }

        // POST: Materiales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMaterial,IdMaterialBase,IdPantone,Hebras")] Material material)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    material.Activo = true;
                    _context.Add(material);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    LoadData();

                    if (Utilities.UniqueValidation(ex, "UQ__MATERIAL__B586E7C0C0D9F1D6"))
                    {
                        ViewData["ErrorMessage"] = "Material ya existente, modifique algún valor";
                    }
                }
            }

            else
            {
                LoadData();
                Utilities.ModelValidations(ModelState, ViewData);
            }

            return View(material);
        }

        // GET: Materiales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materials.FindAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            LoadData();

            return View(material);
        }

        // POST: Materiales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMaterial,IdMaterialBase,IdPantone,Hebras")] Material material)
        {
            if (id != material.IdMaterial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    material.Activo = true;
                    _context.Update(material);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialExists(material.IdMaterial))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException ex)
                {
                    LoadData();

                    if (Utilities.UniqueValidation(ex, "UQ__MATERIAL__B586E7C0C0D9F1D6"))
                    {
                        ViewData["ErrorMessage"] = "Material ya existente, modifique algún valor";
                    }
                }
            }
            else
            {
                LoadData();
                Utilities.ModelValidations(ModelState, ViewData);
            }

            return View(material);
        }

        // GET: Materiales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var material = await _context.Materials
                .Include(m => m.IdMaterialBaseNavigation)
                .FirstOrDefaultAsync(m => m.IdMaterial == id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Materiales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var material = await _context.Materials.FindAsync(id);
            if (material != null)
            {
                material.Activo = false;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MaterialExists(int id)
        {
            return _context.Materials.Any(e => e.IdMaterial == id);
        }


        // GET: Materiales
        public async Task<IActionResult> Inactivos()
        {
            var materialesInactivos = await _context.Materials
                .Include(m => m.IdMaterialBaseNavigation)
                .Where(m => !m.Activo)
                .ToListAsync();

            return View(materialesInactivos);
        }

        [HttpPost, ActionName("Inactivos")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inactivos(int id)
        {
            var material = await _context.Materials
                                 .Include(m => m.IdMaterialBaseNavigation)
                                 .FirstOrDefaultAsync(m => m.IdMaterial == id);

            if (material != null)
            {
                if (material.IdMaterialBaseNavigation.Activo)
                {
                    material.Activo = true;
                    await _context.SaveChangesAsync();
                    ViewData["DoneMessage"] = "Material reactivado";
                }
                else
                {
                    ViewData["ErrorMessage"] = "Reactive el material base primero";
                }
            }

            var materialesInactivos = await _context.Materials
                .Include(m => m.IdMaterialBaseNavigation)
                .Where(m => !m.Activo)
                .ToListAsync();

            return View(materialesInactivos);
        }

        private void LoadData()
        {
            var materialesBases = _context.MaterialBases.ToList();
            var materialBaseItems = materialesBases.Select(mb => new SelectListItem
            {
                Value = $"{mb.IdMaterialBase}",
                Text = $"{mb.CodigoMaterial} - {mb.DescMaterial}"
            })
            .ToList();

            var selectList = new SelectList(materialBaseItems, "Value", "Text");
            ViewData["CodigoMaterialBase"] = selectList;
            ViewData["Hebras"] = Utilities.HebrasOptions();
        }
    }
}
