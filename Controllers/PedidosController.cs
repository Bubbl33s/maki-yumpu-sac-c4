using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakiYumpuSAC.Models;
using MakiYumpuSAC.Resources;

namespace MakiYumpuSAC.Controllers
{
    public class PedidosController : Controller
    {
        private readonly MakiYumpuSacContext _context;

        public PedidosController(MakiYumpuSacContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        public async Task<IActionResult> Index()
        {
            var makiYumpuSacContext = await _context.Pedidos
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.DetallePedidos)
                .Where(p => p.Activo && p.EstadoPedido != "Por revisar")
                .ToListAsync();

            ViewData["SelectClientes"] = new SelectList(
                _context.Clientes
                .Where(c => c.Pedidos.Any(p => p.EstadoPedido != "Por revisar")),
                "NombreCompletoCliente", "NombreCompletoCliente");

            ViewData["SelectEstados"] = Utilities.EstadoPedidosFiltrados();

            return View(makiYumpuSacContext);
        }

        // GET: Solicitudes
        public async Task<IActionResult> Solicitudes()
        {
            var makiYumpuSacContext = await _context.Pedidos
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.DetallePedidos)
                .Where(p => p.EstadoPedido == "Por revisar")
                .ToListAsync();

            return View(makiYumpuSacContext);
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.DetallePedidos)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Revisar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.DetallePedidos)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }
        
        // POST: Solicitudes
        [HttpPost, ActionName("AceptarSolicitud")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AceptarSolicitud(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.DetallePedidos)
                .FirstOrDefaultAsync(m => m.IdPedido == id);

            if (ModelState.IsValid)
            {
                try
                {
                    pedido.IdClienteNavigation.Activo = true;
                    pedido.IdClienteNavigation.Revisado = true;
                    
                    pedido.Activo = true;
                    pedido.IdClienteNavigation.Activo = true;
                    pedido.EstadoPedido = "Pre-aceptado";

                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.IdPedido))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Solicitudes));
            }

            return RedirectToAction("Revisar", id);
        }
        
        // POST: RechazarSolicitud
        [HttpPost, ActionName("RechazarSolicitud")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RechazarSolicitud(int id)
        {
            var pedido = await _context.Pedidos
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.DetallePedidos)
                .FirstOrDefaultAsync(m => m.IdPedido == id);

            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                if (pedido != null)
                {
                    foreach (var detalle in pedido.DetallePedidos)
                    {
                        _context.DetallePedidos.Remove(detalle);
                    }

                    await _context.SaveChangesAsync();

                    _context.Pedidos.Remove(pedido);
                    await _context.SaveChangesAsync();

                    await transaction.CommitAsync();
                }
            }
            catch
            {
                await transaction.RollbackAsync();
            }

            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Solicitudes));
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            LoadData();
            
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pedido pedido, DetallePedido[] detalles)
        {
            pedido.IdClienteNavigation = await _context.Clientes.FindAsync(pedido.IdCliente);
            pedido.IdUsuario = 1;
            pedido.IdUsuarioNavigation = await _context.Usuarios.FindAsync(pedido.IdUsuario);
            pedido.EstadoPedido = "En revisión";
            
            ModelState.Clear();
            TryValidateModel(pedido);
            
            if (ModelState.IsValid)
            {
                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    pedido.FechaGeneracionPedido = DateTime.Now;
                    pedido.Activo = true;
                    _context.Add(pedido);

                    await _context.SaveChangesAsync();

                    foreach (var detalle in detalles)
                    {
                        detalle.IdPedido = pedido.IdPedido;
                        _context.Add(detalle);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    ViewData["DoneMessage"] = "Pedido realizado exitosamente";

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    LoadData();
                    await transaction.RollbackAsync();
                    
                    ViewData["ErrorMessage"] = "Error";
                }
            }

            else
            {
                LoadData();
                Utilities.ModelValidations(ModelState, ViewData);
            }
            
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.DetallePedidos)
                .Where(p => p.IdPedido == id)
                .FirstOrDefaultAsync();

            if (pedido == null)
            {
                return NotFound();
            }
            
            LoadData();
            ViewData["SelectEstados"] = Utilities.EstadoPedidos();

            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPedido,FechaGeneracionPedido,FechaEntrega,IdCliente,IdUsuario,EstadoPedidoId")] Pedido pedido)
        {
            if (id != pedido.IdPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.IdPedido))
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
            
            LoadData();
            
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .FirstOrDefaultAsync(m => m.IdPedido == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                pedido.Activo = false;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.IdPedido == id);
        }
        
        // GET: Inactivos
        public async Task<IActionResult> Inactivos()
        {
            var pedidosInactivos = await _context.Pedidos
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.DetallePedidos)
                .Where(p => !p.Activo && p.EstadoPedido != "Por revisar")
                .ToListAsync();

            return View(pedidosInactivos);
        }
        
        // POST: Inactivos
        [HttpPost, ActionName("Inactivos")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Inactivos(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);

            if (pedido != null)
            {
                pedido.Activo = true;
                await _context.SaveChangesAsync();

                ViewData["DoneMessage"] = "Pedido reactivado";
            }

            var pedidosInactivos = await _context.Pedidos
                .Include(p => p.IdClienteNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.DetallePedidos)
                .Where(p => !p.Activo && p.EstadoPedido != "Por revisar")
                .ToListAsync();

            return View(pedidosInactivos);
        }

        private void LoadData()
        {
            var clientesItems = _context.Clientes
                .Where(c => c.Activo && c.Revisado)
                .ToList()
                .Select(c => new SelectListItem
                {
                    Value = $"{c.IdCliente}",
                    Text = $"{c.IdCliente} - {c.NombreCompletoCliente}"
                })
                .ToList();

            ViewData["IdCliente"] = new SelectList(clientesItems, "Value", "Text");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuario", "ApPatUsuario");
        }
    }
}
