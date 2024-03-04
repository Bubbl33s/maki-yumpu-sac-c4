using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakiYumpuSAC.Models;
using MakiYumpuSAC.Services.Contract;

namespace MakiYumpuSAC.Controllers
{
    public class FormPedidosController : Controller
    {
        private readonly MakiYumpuSacContext _context;
        private readonly IEmailService _emailService;

        public FormPedidosController(MakiYumpuSacContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // GET: FormPedidos
        public async Task<IActionResult> Index()
        {
            return View(await _context.FormPedidos.ToListAsync());
        }

        // GET: FormPedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formPedido = await _context.FormPedidos
                .FirstOrDefaultAsync(m => m.IdFormPedido == id);
            if (formPedido == null)
            {
                return NotFound();
            }

            return View(formPedido);
        }

        // GET: FormPedidos/Create
        public IActionResult Create()
        {
            return View();
        }

            // POST: FormPedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdFormPedido,NombreCompletoCliente,CorreoCliente,PaisCliente,Fecha")] FormPedido formPedido, DetalleFormPedido[] detalles)
        {
            Console.WriteLine("HOALALALLALALALAL1111111111111");
            try
            {
                formPedido.Fecha = DateTime.Now;
                _context.Add(formPedido);
                await _context.SaveChangesAsync();

                Console.WriteLine("HOALALALLALALALAL1111111111111");

                foreach (var detalle in detalles)
                {
                    detalle.IdFormPedido = formPedido.IdFormPedido;
                    _context.Add(detalle);
                }
                Console.WriteLine("HOALALALLALALALAL222222222222");

                await EnviarCorreo(formPedido);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                Console.WriteLine("INVALIDO");
                return View(formPedido);
            }
        }

        // GET: FormPedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formPedido = await _context.FormPedidos.FindAsync(id);
            if (formPedido == null)
            {
                return NotFound();
            }
            return View(formPedido);
        }

        // POST: FormPedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdFormPedido,NombreCompletoCliente,CorreoCliente,PaisCliente,Fecha")] FormPedido formPedido)
        {
            if (id != formPedido.IdFormPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(formPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormPedidoExists(formPedido.IdFormPedido))
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
            return View(formPedido);
        }

        // GET: FormPedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formPedido = await _context.FormPedidos
                .FirstOrDefaultAsync(m => m.IdFormPedido == id);
            if (formPedido == null)
            {
                return NotFound();
            }

            return View(formPedido);
        }

        // POST: FormPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formPedido = await _context.FormPedidos.FindAsync(id);
            if (formPedido != null)
            {
                _context.FormPedidos.Remove(formPedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormPedidoExists(int id)
        {
            return _context.FormPedidos.Any(e => e.IdFormPedido == id);
        }

        private async Task EnviarCorreo(FormPedido pedido)
        {
            EmailDTO email = new()
            {
                Para = pedido.CorreoCliente,
                Asunto = "Pedido Realizado",
                Contenido = "Prueba de email"
            };

            Console.WriteLine(email.Para);
            Console.WriteLine("HOALALALLALALALAL");

            _emailService.SendEmail(email);
        }
    }
}
