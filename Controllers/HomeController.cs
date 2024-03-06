using MakiYumpuSAC.Models;
using MakiYumpuSAC.Resources;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using MakiYumpuSAC.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace MakiYumpuSAC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MakiYumpuSacContext _context;
        private readonly IEmailService _emailService;


        public HomeController(ILogger<HomeController> logger, MakiYumpuSacContext context, IEmailService emailService)
        {
            _logger = logger;
            _context = context;
            _emailService = emailService;
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
            LoadData();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PedidoCliente(Cliente cliente, Pedido pedido, DetallePedido[] detalles, string tablaHTML)
        {
            Console.WriteLine(tablaHTML);
            // Validar los modelos y agregar errores al ModelState
            ModelState.Clear();
            TryValidateModel(cliente);

            if (ModelState.IsValid)
            {
                // Comienza la transacción
                using var transaction = await _context.Database.BeginTransactionAsync();

                try
                {
                    // Verificar si el cliente ya existe por su correo electrónico
                    var existingCliente = await _context.Clientes.FirstOrDefaultAsync(c => c.CorreoCliente == cliente.CorreoCliente);

                    if (existingCliente != null)
                    {
                        // Utilizar el cliente existente en lugar de crear uno nuevo
                        cliente = existingCliente;
                    }
                    else
                    {
                        // Configurar el nuevo cliente como inactivo
                        cliente.Activo = false;
                        _context.Add(cliente);
                        await _context.SaveChangesAsync();
                    }

                    // Asignar la propiedad de navegación IdClienteNavigation al pedido
                    pedido.FechaGeneracionPedido = pedido.FechaEntrega = DateTime.Now;
                    pedido.EstadoPedido = "Por revisar";
                    pedido.IdClienteNavigation = cliente; // Asignación directa
                    pedido.IdUsuario = 1;
                    pedido.Activo = false;
                    _context.Add(pedido);

                    await _context.SaveChangesAsync();

                    foreach (var detalle in detalles)
                    {
                        detalle.IdPedido = pedido.IdPedido;
                        _context.Add(detalle);
                    }

                    await _context.SaveChangesAsync();

                    if (pedido.IdClienteNavigation != null)
                    {
                        CorreoPedido(pedido, tablaHTML);
                    }

                    // Confirma la transacción
                    await transaction.CommitAsync();

                    ViewData["DoneMessage"] = "Pedido realizado exitosamente";

                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    LoadData();

                    // Revierte la transacción si hay un error
                    await transaction.RollbackAsync();
                    ViewData["ErrorMessage"] = "Error";
                }
            }

            else
            {
                LoadData();

                Utilities.ModelValidations(ModelState, ViewData);
                Console.WriteLine(ViewData["ErrorMessage"]);
            }

            return View(pedido);
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

        private void LoadData()
        {
            ViewData["Paises"] = Utilities.CountriesOptions();
        }

        private void CorreoPedido(Pedido pedido, string tablaHTML)
        {
            EmailDTO email = new()
            {
                Para = pedido.IdClienteNavigation.CorreoCliente,
                Asunto = "Pedido Realizado",
                Contenido = $@"
                            <html>
                                <head>
                                    <link
                                        href='https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css'
                                        rel='stylesheet'>   
                                </head>
                                <body>
                                    {tablaHTML}    
                                </body>
                            </html>                  
                            "
            };

            _emailService.SendEmail(email);
        }
    }
}
