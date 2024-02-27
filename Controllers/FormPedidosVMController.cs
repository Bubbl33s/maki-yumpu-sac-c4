using MakiYumpuSAC.Models;
using MakiYumpuSAC.Models.ViewModels;
using MakiYumpuSAC.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MakiYumpuSAC.Controllers
{
    [Authorize]
    public class FormPedidosVMController : Controller
    {
        private readonly MakiYumpuSacContext _context;

        public FormPedidosVMController(MakiYumpuSacContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            ViewData["Countries"] = Utilities.CountriesOptions();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] FormPedidoVM oFormPedidoVM)
        {
            Console.WriteLine(oFormPedidoVM.ToString());
            FormPedido oFormPedido = oFormPedidoVM.oFormPedido;
            oFormPedido.DetalleFormPedidos = oFormPedidoVM.oDetalleFormPedido;

            _context.FormPedidos.Add(oFormPedido);
            await _context.SaveChangesAsync();

            return Json(new { respuesta = true });
        }
    }
}
