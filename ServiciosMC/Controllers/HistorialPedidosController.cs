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
using ServiciosMC.Models;

namespace ServiciosMC.Controllers
{
    [Authorize(Policy = "USUARIO_MULTIPLE")]
    public class HistorialPedidosController : Controller
    {
        private readonly IConfiguration config;
        private readonly ILogger<HistorialPedidosController> _logger;
        public HistorialPedidosController(ILogger<HistorialPedidosController> logger, IConfiguration Iconfig)
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

        [HttpPost]
        public async Task<JsonResult> ListaPedidos(infoConsultaPedidos usrData)
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "obtengoPedidosMC";

                using (HttpClient httpClient = new HttpClient())
                {
                    Debug.WriteLine("entra dataUsuario: " + usrData);
                    var datos = JsonSerializer.Serialize(usrData);
                    Debug.WriteLine("datos: " + datos);
                    var contenido = new StringContent(datos, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(URL, contenido);

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
                // Maneja problemas de conectividad o errores de solicitud HTTP.
                Debug.WriteLine("HttpRequestException: " + ex.Message);
                return Json(new { success = false, errorMensaje = "Ocurrió un error al obtener el listado de pedidos, no se obtuvo respuesta del servidor." });
            }
            catch (TaskCanceledException ex)
            {
                // Maneja el timeout de la solicitud.
                Debug.WriteLine("TaskCanceledException (posible timeout): " + ex.Message);
                return Json(new { success = false, errorMensaje = "La solicitud al servidor ha superado el tiempo de espera." });
            }
            catch (Exception ex)
            {
                // Maneja cualquier otra excepción.
                Debug.WriteLine("Exception: " + ex.Message);
                return Json(new { success = false, errorMensaje = "Error al procesar los datos: " + ex.Message });
            }
        }




    }
}
