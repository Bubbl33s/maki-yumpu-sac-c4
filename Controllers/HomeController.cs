using MakiYumpuSAC.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace MakiYumpuSAC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MakiYumpuSacContext _context;

        public HomeController(ILogger<HomeController> logger, MakiYumpuSacContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexAdmin()
        {
            return View();
        }

        public IActionResult PedidoCliente()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PedidoCliente([Bind("IdFormPedido,NombreCompletoCliente,CorreoCliente,PaisCliente,Fecha")] FormPedido formPedido, DetalleFormPedido[] detalles)
        {
            try
            {
                formPedido.Fecha = DateTime.Now;
                _context.Add(formPedido);
                await _context.SaveChangesAsync();

                foreach (var detalle in detalles)
                {
                    detalle.IdFormPedido = formPedido.IdFormPedido;
                    _context.Add(detalle);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(formPedido);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("IniciarSesion", "Inicio");
        }
    }
}
