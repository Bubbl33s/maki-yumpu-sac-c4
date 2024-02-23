using Microsoft.AspNetCore.Mvc;

using MakiYumpuSAC.Models;
using MakiYumpuSAC.Resources;
using MakiYumpuSAC.Services.Contract;

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MakiYumpuSAC.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public InicioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string login, string password)
        {
            Usuario usuarioEncontrado = await _usuarioService.GetUsuario(login, Utilities.EncryptKey(password));

            if (usuarioEncontrado == null)
            {
                ViewData["Mensaje"] = "No se encontraron coincidencias";

                return View();
            }

            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,
                usuarioEncontrado.NombresUsuario + " " +
                usuarioEncontrado.ApPatUsuario + " " +
                usuarioEncontrado.ApMatUsuario)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true,
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties
                );

            return RedirectToAction("IndexAdmin", "Home");
        }
    }
}