using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakiYumpuSAC.Models;

namespace MakiYumpuSAC.Controllers
{
    public class CardexMaterialesController : Controller
    {
        private readonly MakiYumpuSacContext _context;

        public CardexMaterialesController(MakiYumpuSacContext context)
        {
            _context = context;
        }

        // GET: CardexMateriales
        public async Task<IActionResult> Index()
        {
            var makiYumpuSacContext = _context.CardexMaterials.Include(c => c.IdMaterialNavigation);
            return View(await makiYumpuSacContext.ToListAsync());
        }

        // GET: CardexMateriales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardexMaterial = await _context.CardexMaterials
                .Include(c => c.IdMaterialNavigation)
                .FirstOrDefaultAsync(m => m.IdMaterial == id);
            if (cardexMaterial == null)
            {
                return NotFound();
            }

            return View(cardexMaterial);
        }

        // GET: CardexMateriales/Create
        public IActionResult Create()
        {
            ViewData["IdMaterial"] = new SelectList(_context.Materials, "IdMaterial", "IdMaterial");
            return View();
        }

        // POST: CardexMateriales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMaterial,Tipo,Cantidad,Stock,Conos")] CardexMaterial cardexMaterial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardexMaterial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMaterial"] = new SelectList(_context.Materials, "IdMaterial", "IdMaterial", cardexMaterial.IdMaterial);
            return View(cardexMaterial);
        }

        // GET: CardexMateriales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardexMaterial = await _context.CardexMaterials.FindAsync(id);
            if (cardexMaterial == null)
            {
                return NotFound();
            }
            ViewData["IdMaterial"] = new SelectList(_context.Materials, "IdMaterial", "IdMaterial", cardexMaterial.IdMaterial);
            return View(cardexMaterial);
        }

        // POST: CardexMateriales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMaterial,Tipo,Cantidad,Stock,Conos")] CardexMaterial cardexMaterial)
        {
            if (id != cardexMaterial.IdMaterial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardexMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardexMaterialExists(cardexMaterial.IdMaterial))
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
            ViewData["IdMaterial"] = new SelectList(_context.Materials, "IdMaterial", "IdMaterial", cardexMaterial.IdMaterial);
            return View(cardexMaterial);
        }

        // GET: CardexMateriales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardexMaterial = await _context.CardexMaterials
                .Include(c => c.IdMaterialNavigation)
                .FirstOrDefaultAsync(m => m.IdMaterial == id);
            if (cardexMaterial == null)
            {
                return NotFound();
            }

            return View(cardexMaterial);
        }

        // POST: CardexMateriales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cardexMaterial = await _context.CardexMaterials.FindAsync(id);
            if (cardexMaterial != null)
            {
                _context.CardexMaterials.Remove(cardexMaterial);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardexMaterialExists(int id)
        {
            return _context.CardexMaterials.Any(e => e.IdMaterial == id);
        }
    }
}
