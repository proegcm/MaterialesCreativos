using ServiciosMC.Helpers;
using ServiciosMC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ServiciosMC.MaterialesCreativos;

namespace ServiciosMC.Controllers
{
    public class LoginController : Controller
    {
        /// private object resultado;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Autenticacion(LoginViewModel loginViewModel)
        {
            Debug.WriteLine("LOGINNNN: " + loginViewModel.Usuario);
            ResultadoViewModel resultado = new ResultadoViewModel();
            Autenticacion autenticacion = new Autenticacion();
            resultado = autenticacion.ValidarCredenciales(loginViewModel);

            if (resultado.Estado == true)
            {
                Debug.WriteLine("TIPO ---> " + resultado.Tipo);
                var usuarioInfo = new List<Claim>()
                            {
                                    new Claim(ClaimTypes.Name,loginViewModel.Usuario),
                                    new Claim(ClaimTypes.Role,resultado.Tipo),
                                    new Claim("TIPO_USUARIO",resultado.Tipo),
                                    new Claim("Usuario",loginViewModel.Usuario),
                                    new Claim("Password",loginViewModel.Password)
                            };
                Debug.WriteLine("usuarioInfo: " + usuarioInfo);
                var usuarioIdentity = new ClaimsIdentity(usuarioInfo, "UsuarioInfo");
                var userPrincipal = new ClaimsPrincipal(new[] { usuarioIdentity });
                HttpContext.SignInAsync(userPrincipal);
            }
            Debug.WriteLine(resultado);
            return Json(resultado);
        }

        public ActionResult Salir()
        {

            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

    }
}
