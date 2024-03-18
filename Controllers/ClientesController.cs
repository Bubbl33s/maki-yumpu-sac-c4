using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakiYumpuSAC.Models;
using MakiYumpuSAC.Resources;
using Microsoft.AspNetCore.Authorization;

namespace MakiYumpuSAC.Controllers
{
    [Authorize]
    public class ClientesController : Controller
    {
        private readonly MakiYumpuSacContext _context;

        public ClientesController(MakiYumpuSacContext context)
        {
            _context = context;
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes
                .Include(c => c.Pedidos)
                .Where(c => c.Activo)
                .ToListAsync());
        }
        
        // GET: Solicitudes
        public async Task<IActionResult> Solicitudes()
        {
            var solicitudes = await _context.Clientes
                .Where(c => !c.Revisado)
                .ToListAsync();

            return View(solicitudes);
        }
        
        // POST: Solicitudes
        [HttpPost, ActionName("AceptarSolicitud")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AceptarSolicitud(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            cliente.Revisado = true;
            cliente.Activo = true;

            return RedirectToAction(nameof(Solicitudes));
        }
        
        // POST: Solicitudes
        [HttpPost, ActionName("RechazarSolicitud")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RechazarSolicitud(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Pedidos)
                    .ThenInclude(p => p.DetallePedidos)
                .FirstOrDefaultAsync(c => c.IdCliente == id);

            if (cliente == null)
            {
                return NotFound();
            }

            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                foreach (var pedido in cliente.Pedidos)
                {
                    foreach (var detalle in pedido.DetallePedidos)
                    {
                        _context.DetallePedidos.Remove(detalle);
                    }

                    _context.Pedidos.Remove(pedido);
                }

                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Solicitudes));
        }

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .Include(c => c.Pedidos)
                    .ThenInclude(p => p.DetallePedidos)
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            LoadData();
            
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,NombreCompletoCliente,CorreoCliente,PaisCliente")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    cliente.Activo = true;
                    cliente.Revisado = true;
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    if (Utilities.UniqueValidation(ex, "IX_CLIENTE_correo_cliente"))
                    {
                        ViewData["ErrorMessage"] = "Correo ya registrado";
                    }
                    
                    if (Utilities.UniqueValidation(ex, "IX_CLIENTE_nombre_completo_cliente"))
                    {
                        ViewData["ErrorMessage"] = "Nombre ya registrado";
                    }
                    
                    LoadData();
                }
            }
            else
            {
                LoadData();
                Utilities.ModelValidations(ModelState, ViewData);
            }
            
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            
            LoadData();
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,NombreCompletoCliente,CorreoCliente,PaisCliente")] Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    cliente.Activo = true;
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    if (Utilities.UniqueValidation(ex, "IX_CLIENTE_correo_cliente"))
                    {
                        ViewData["ErrorMessage"] = "Correo ya registrado";
                    }
                    
                    if (Utilities.UniqueValidation(ex, "IX_CLIENTE_nombre_completo_cliente"))
                    {
                        ViewData["ErrorMessage"] = "Nombre ya registrado";
                    }
                    
                    LoadData();
                }
            }
            else
            {
                LoadData();
                Utilities.ModelValidations(ModelState, ViewData);
            }
            
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Pedidos)
                .Where(c => c.IdCliente == id)
                .FirstOrDefaultAsync();
            
            if (cliente != null)
            {
                cliente.Activo = false;

                foreach (var pedido in cliente.Pedidos)
                {
                    pedido.Activo = false;
                }
                
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }
        
        // GET: Clientes/Inactivos
        public async Task<IActionResult> Inactivos()
        {
            var clientes = await _context.Clientes
                .Include(c => c.Pedidos)
                .Where(c => !c.Activo)
                .ToListAsync();

            return View(clientes);
        }

        [HttpPost, ActionName("Inactivos")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inactivos(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente != null)
            {
                cliente.Activo = true;
                await _context.SaveChangesAsync();
                ViewData["DoneMessage"] = "Cliente reactivado";
            }
            
            var clientesInactivos = await _context.Clientes
                .Include(c => c.Pedidos)
                .Where(c => !c.Activo)
                .ToListAsync();

            return View(clientesInactivos);
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
        
        private void LoadData()
        {
            ViewData["Paises"] = Utilities.CountriesOptions();
        }
    }
}
