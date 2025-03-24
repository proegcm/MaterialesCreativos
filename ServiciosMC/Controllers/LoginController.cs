using ServiciosMC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using ServiciosMC.MaterialesCreativos;

namespace ServiciosMC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;

        public LoginController(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Autenticacion(LoginViewModel loginViewModel)
        {
            Debug.WriteLine("LOGIN: " + loginViewModel.Usuario);
            Autenticacion autenticacion = new Autenticacion(_config);
            ResultadoViewModel resultado = await autenticacion.ValidarCredencialesNuevo(loginViewModel);

            if (resultado.Estado == true)
            {
                Debug.WriteLine("TIPO ---> " + resultado.Tipo);
                var usuarioInfo = new List<Claim>()
                            {
                                    new Claim(ClaimTypes.Name,loginViewModel.Usuario),
                                    new Claim(ClaimTypes.Role,resultado.Tipo),
                                    new Claim(ClaimTypes.NameIdentifier, resultado.Nombre),
                                    new Claim("TIPO_USUARIO",resultado.Tipo),
                                    new Claim("IDUSR",resultado.ID),
                                    new Claim("Usuario",loginViewModel.Usuario),
                                    new Claim("Password",loginViewModel.Password)
                            };
                var usuarioIdentity = new ClaimsIdentity(usuarioInfo, "UsuarioInfo");
                var userPrincipal = new ClaimsPrincipal(new[] { usuarioIdentity });
                await HttpContext.SignInAsync(userPrincipal);
            }
            return Json(resultado);
        }

        public ActionResult Salir()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

    }
}
