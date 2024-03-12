using MakiYumpuSAC.Models;
using MakiYumpuSAC.Resources;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MakiYumpuSAC.Services.Contract;
using Microsoft.EntityFrameworkCore;
using System.Text;

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
        public async Task<IActionResult> PedidoCliente(Cliente cliente, Pedido pedido, DetallePedido[] detalles)
        {
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
                        NotificarPedido(pedido);
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

        private void NotificarPedido(Pedido pedido)
        {
            StringBuilder sb = new StringBuilder();

            // Estilos CSS para la tabla
            string tablaStyle = @"
                                <style>
                                    table {
                                        border-collapse: collapse;
                                        width: 100%;
                                    }

                                    th, td {
                                        border: 1px solid #dddddd;
                                        padding: 8px;
                                    }

                                    th {
                                        background-color: #f2f2f2;
                                    }
                                </style>";

            // Apertura del cuerpo del correo electrónico y la tabla
            sb.Append("<html>");
            sb.Append("<head>");
            sb.Append(tablaStyle); // Agregar estilos CSS
            sb.Append("</head>");
            sb.Append("<body>");
            sb.Append("<table>");

            // Encabezados de la tabla
            sb.Append("<tr>");
            sb.Append("<th>Prenda</th>");
            sb.Append("<th>Detalles</th>");
            sb.Append("<th>Cantidad</th>");
            sb.Append("</tr>");

            // Detalles del pedido
            foreach (var detalle in pedido.DetallePedidos)
            {
                sb.Append("<tr>");
                sb.Append($"<td>{detalle.DescPrenda}</td>");
                sb.Append($"<td>{detalle.DetallesPrenda}</td>");
                sb.Append($"<td style='text-align: center;'>{detalle.CantidadPrenda}</td>");
                sb.Append("</tr>");
            }

            // Cerrar la tabla y el cuerpo del correo electrónico
            sb.Append("</table>");
            sb.Append("</body>");
            sb.Append("</html>");

            EmailDTO email = new()
            {
                Para = pedido.IdClienteNavigation.CorreoCliente,
                Asunto = "Pedido Realizado",
                Contenido = sb.ToString()
            };

            _emailService.SendEmail(email);
        }
    }
}
