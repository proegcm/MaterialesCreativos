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
                var usuarioInfo = new List<Claim>()
                            {
                                    new Claim(ClaimTypes.Name,loginViewModel.Usuario),
                                    new Claim("TIPO_USUARIO",resultado.Tipo),
                                    new Claim("Usuario",loginViewModel.Usuario),
                                    new Claim("Password",loginViewModel.Password)
                            };
                var usuarioIdentity = new ClaimsIdentity(usuarioInfo, "UsuarioInfo");
                var userPrincipal = new ClaimsPrincipal(new[] { usuarioIdentity });
                HttpContext.SignInAsync(userPrincipal);
            }
            
            return Json(resultado);
        }

        public ActionResult Salir()
        {

            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        //public IActionResult Info()
        //{

        //    string login = Helper.config.GetSection("Servicios:WSLOGIN").Value;
        //    login += "\n" + Helper.config.GetSection("Servicios:WSCOBERTURAS").Value;
        //    login += "\n" + Helper.config.GetSection("Servicios:WSLOGIN").Value;
        //    login += "\n" + Helper.config.GetSection("Servicios:WSDEPARTAMENTOS").Value;
        //    login += "\n" + Helper.config.GetSection("Servicios:WSTOMASERVICIOGF").Value;
        //    login += "\n" + Helper.config.GetSection("Servicios:WSTOMASERVICIO").Value;
        //    login += "\n" + Helper.config.GetSection("Servicios:WSPERFIL").Value;
        //    login += "\n" + Helper.config.GetSection("Servicios:WSMUNICIPIOS").Value;


        //    ViewBag.Enviroment = Helper.Enviroment + "<br>" + login;
        //    return View();
        //}


    }
}
