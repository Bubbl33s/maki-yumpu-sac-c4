using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakiYumpuSAC.Models;
using Microsoft.AspNetCore.Authorization;

namespace MakiYumpuSAC.Controllers
{
    [Authorize]
    public class MaterialesBaseController : Controller
    {
        private readonly MakiYumpuSacContext _context;

        public MaterialesBaseController(MakiYumpuSacContext context)
        {
            _context = context;
        }

        // GET: MaterialBase
        public async Task<IActionResult> Index()
        {

            return View(
                await _context.MaterialBases
                .Where(m => m.Activo)
                .ToListAsync()
                );
        }

        // GET: MaterialBase/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialBase = await _context.MaterialBases
                .Include(mb => mb.Materials)
                .FirstOrDefaultAsync(m => m.IdMaterialBase == id);

            if (materialBase == null)
            {
                return NotFound();
            }

            return View(materialBase);
        }

        /*public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialBase = await _context.MaterialBases
                .FirstOrDefaultAsync(m => m.IdMaterialBase == id);
            if (materialBase == null)
            {
                return NotFound();
            }

            return View(materialBase);
        }*/

        // GET: MaterialBase/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaterialBase/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMaterialBase,CodigoMaterial,DescMaterial")] MaterialBase materialBase)
        {
            if (ModelState.IsValid)
            {
                materialBase.Activo = true;
                _context.Add(materialBase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materialBase);
        }

        // GET: MaterialBase/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialBase = await _context.MaterialBases.FindAsync(id);
            if (materialBase == null)
            {
                return NotFound();
            }
            return View(materialBase);
        }

        // POST: MaterialBase/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMaterialBase,CodigoMaterial,DescMaterial")] MaterialBase materialBase)
        {
            if (id != materialBase.IdMaterialBase)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    materialBase.Activo = true;
                    _context.Update(materialBase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialBaseExists(materialBase.IdMaterialBase))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(materialBase);
        }

        // GET: MaterialBase/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialBase = await _context.MaterialBases
                .FirstOrDefaultAsync(m => m.IdMaterialBase == id);
            if (materialBase == null)
            {
                return NotFound();
            }

            return View(materialBase);
        }

        // POST: MaterialBase/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialBase = await _context.MaterialBases.FindAsync(id);
            if (materialBase != null)
            {
                materialBase.Activo = false;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MaterialBaseExists(int id)
        {
            return _context.MaterialBases.Any(e => e.IdMaterialBase == id);
        }

        public async Task<IActionResult> Inactivos()
        {
            return View(
                await _context.MaterialBases
                .Where(m => !m.Activo)
                .ToListAsync()
                );
        }

        [HttpPost, ActionName("Reactivar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reactivar(int id)
        {
            var material = await _context.MaterialBases.FindAsync(id);
            if (material != null)
            {
                material.Activo = true;
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
