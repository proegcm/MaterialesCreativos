using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiciosMC.Helpers;
using ServiciosMC.Models;

namespace ServiciosMC.Controllers
{
    [Authorize(Policy = "USUARIO_ADMIN")]
    public class PanelControlController : Controller
    {
        private readonly IConfiguration config;
        private readonly ILogger<PanelControlController> _logger;

        public PanelControlController(ILogger<PanelControlController> logger, IConfiguration Iconfig)
        {
            _logger = logger;
            config = Iconfig;
        }

        public IActionResult Index()
        {
            return View();
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

        /*Obtiene todas las empresas de paquetería de la base de datos*/
        [HttpPost]
        public async Task<JsonResult> ConsultaPaqueterias()
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "consultaPaqueteriasMC";

                using (HttpClient httpClient = new HttpClient())
                {

                    var response = await httpClient.PostAsync(URL, null);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine("Respuesta del servidor: " + responseBody);
                        return Json(new { success = true, respuesta = responseBody });
                    }
                    else
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var errorObject = JsonSerializer.Deserialize<Dictionary<string, string>>(responseBody);
                        string errorMensaje = errorObject.ContainsKey("error") ? errorObject["error"] : "Error desconocido";
                        Debug.WriteLine("Código:" + errorMensaje);
                        return Json(new { success = false, errorMensaje });
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine("HttpRequestException: " + ex.Message);
                return Json(new { success = false, errorMensaje = "Ocurrió un error al obtener el listado de pilotos, no se obtuvo respuesta del servidor." });
            }
            catch (TaskCanceledException ex)
            {
                Debug.WriteLine("TaskCanceledException (posible timeout): " + ex.Message);
                return Json(new { success = false, errorMensaje = "La solicitud al servidor ha superado el tiempo de espera." });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                return Json(new { success = false, errorMensaje = "Error al procesar los datos: " + ex.Message });
            }
        }


        /*Obtiene roles*/
        [HttpPost]
        public async Task<JsonResult> ConsultaRoles()
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "consultaRolesMC";

                using (HttpClient httpClient = new HttpClient())
                {

                    var response = await httpClient.PostAsync(URL, null);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine("Respuesta del servidor: " + responseBody);
                        return Json(new { success = true, respuesta = responseBody });
                    }
                    else
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var errorObject = JsonSerializer.Deserialize<Dictionary<string, string>>(responseBody);
                        string errorMensaje = errorObject.ContainsKey("error") ? errorObject["error"] : "Error desconocido";
                        Debug.WriteLine("Código:" + errorMensaje);
                        return Json(new { success = false, errorMensaje });
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine("HttpRequestException: " + ex.Message);
                return Json(new { success = false, errorMensaje = "Ocurrió un error al obtener el listado de pilotos, no se obtuvo respuesta del servidor." });
            }
            catch (TaskCanceledException ex)
            {
                Debug.WriteLine("TaskCanceledException (posible timeout): " + ex.Message);
                return Json(new { success = false, errorMensaje = "La solicitud al servidor ha superado el tiempo de espera." });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                return Json(new { success = false, errorMensaje = "Error al procesar los datos: " + ex.Message });
            }
        }


        /*Obtiene Usuarios*/
        [HttpPost]
        public async Task<JsonResult> ConsultaUsuarios()
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "consultaUsuariosMC";

                using (HttpClient httpClient = new HttpClient())
                {

                    var response = await httpClient.PostAsync(URL, null);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine("Respuesta del servidor: " + responseBody);
                        return Json(new { success = true, respuesta = responseBody });
                    }
                    else
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var errorObject = JsonSerializer.Deserialize<Dictionary<string, string>>(responseBody);
                        string errorMensaje = errorObject.ContainsKey("error") ? errorObject["error"] : "Error desconocido";
                        Debug.WriteLine("Código:" + errorMensaje);
                        return Json(new { success = false, errorMensaje });
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine("HttpRequestException: " + ex.Message);
                return Json(new { success = false, errorMensaje = "Ocurrió un error al obtener el listado de pilotos, no se obtuvo respuesta del servidor." });
            }
            catch (TaskCanceledException ex)
            {
                Debug.WriteLine("TaskCanceledException (posible timeout): " + ex.Message);
                return Json(new { success = false, errorMensaje = "La solicitud al servidor ha superado el tiempo de espera." });
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex.Message);
                return Json(new { success = false, errorMensaje = "Error al procesar los datos: " + ex.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult> IngresarUsuario(infoUsuarioIngreso pedidoData)
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "ingresoPedidoMC";

                using (HttpClient httpClient = new HttpClient())
                {
                    var datos = JsonSerializer.Serialize(pedidoData);
                    var contenido = new StringContent(datos, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(URL, contenido);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonSerializer.Deserialize<Dictionary<string, string>>(responseBody);
                        string mensaje = responseObject["mensaje"];

                        return Json(new { success = true, respuesta = mensaje });
                    }
                    else
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        var errorObject = JsonSerializer.Deserialize<Dictionary<string, string>>(responseBody);
                        string errorMensaje = errorObject["error"];
                        Debug.WriteLine("Código:" + errorMensaje);
                        return Json(new { success = false, errorMensaje });

                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, errorMensaje = "Error al procesar los datos: " + ex.Message });
            }
        }


    }
}
