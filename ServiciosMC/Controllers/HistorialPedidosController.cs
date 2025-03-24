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
        public async Task<JsonResult> ListaPedidos(infoHistorial dataHis)
        {
            try
            {
                Helper helper = new Helper();
                LoginViewModel login = helper.Usuario(HttpContext);
                string usuarioLogin = login.Usuario;
                dataHis.usuarioConsulta = usuarioLogin;

                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "obtengoHistorialPedidosMC";

                using (HttpClient httpClient = new HttpClient())
                {

                    var datos = JsonSerializer.Serialize(dataHis);
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
                return Json(new { success = false, errorMensaje = "Ocurrió un error al obtener el listado de pedidos, no se obtuvo respuesta del servidor. Por favor, refresque la página." });
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
                return Json(new { success = false, errorMensaje = ex.Message });
            }
        }

        /*Obtiene Usuarios*/
        [HttpPost]
        public async Task<JsonResult> ConsultaUsuarios()
        {
            try
            {
                Helper helper = new Helper();
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "consultaUsuariosMC";

                using (HttpClient httpClient = new HttpClient())
                {

                    var response = await httpClient.PostAsync(URL, null);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        Debug.WriteLine(":) Respuesta: " + responseBody);

                        // Deserializa el JSON a un JsonElement usando System.Text.Json
                        var data = JsonSerializer.Deserialize<JsonElement>(responseBody);
                        Debug.WriteLine(":) data: " + data);
                        // Crea una lista filtrada con solo los campos necesarios
                        var usuariosFiltrados = new List<object>();

                        var username = User.Identity.IsAuthenticated ? User.Identity.Name : "";
                        var tipoUsuario = User.Claims.FirstOrDefault(c => c.Type == "TIPO_USUARIO")?.Value;

                        // Recorre el array de usuarios en el JSON
                        foreach (var usuario in data.GetProperty("listadoUsuarios").EnumerateArray())
                        {
                            // Si es administrador, agregar todos los usuarios
                            if (tipoUsuario == "ADMINISTRADOR")
                            {
                                usuariosFiltrados.Add(new
                                {
                                    id_usuario = usuario.GetProperty("id_usuario").GetInt32(),
                                    nombre = usuario.GetProperty("nombre").GetString(),
                                    rol = usuario.GetProperty("rol").GetString(),
                                    username = usuario.GetProperty("username").GetString()
                                });
                            }
                            // Si no es administrador, agregar solo su propio usuario
                            else 
                            {
                                if (usuario.GetProperty("username").GetString() == username)
                                {
                                    usuariosFiltrados.Add(new
                                    {
                                        id_usuario = usuario.GetProperty("id_usuario").GetInt32(),
                                        nombre = usuario.GetProperty("nombre").GetString(),
                                        rol = usuario.GetProperty("rol").GetString(),
                                        username = usuario.GetProperty("username").GetString()
                                    });
                                }
                                    
                            }

                        }



                        return Json(new { success = true, listadoUsuarios = usuariosFiltrados });
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
                return Json(new { success = false, errorMensaje = "Ocurrió un error al obtener el listado de ususarios, no se obtuvo respuesta del servidor." });
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



    }
}
