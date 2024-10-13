using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
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
                return Json(new { success = false, errorMensaje = "Ocurrió un error al obtener el listado de paqueterías, no se obtuvo respuesta del servidor." });
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
                return Json(new { success = false, errorMensaje = "Ocurrió un error al obtener el listado de roles, no se obtuvo respuesta del servidor." });
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

        /* INGRESO DE USUARIOS / ROLES / PAQUETERIAS */
        [HttpPost]
        public async Task<JsonResult> IngresarUsuario(infoUsuarioIngreso usuarioData)
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "ingresoUsuarioMC";

                using (HttpClient httpClient = new HttpClient())
                {
                    var datos = JsonSerializer.Serialize(usuarioData);
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

        [HttpPost]
        public async Task<JsonResult> IngresarRol(infoRolIngreso rolData)
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "ingresoRolMC";

                using (HttpClient httpClient = new HttpClient())
                {
                    var datos = JsonSerializer.Serialize(rolData);
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

        [HttpPost]
        public async Task<JsonResult> IngresarPaqueteria(infoPaqueteriaIngreso paqData)
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "ingresoPaqueteriaMC";

                using (HttpClient httpClient = new HttpClient())
                {
                    var datos = JsonSerializer.Serialize(paqData);
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

        /* MODIFICACIÓN DE USUARIOS / ROLES / PAQUETERIAS */
        [HttpPost]
        public async Task<JsonResult> EditarUsuario(infoUsuarioEditar modData)
        {
            Debug.WriteLine(modData.ToString());
            try
            {
                Helper helper = new Helper();
                string usuariocambio = User.FindFirst("IDUSR")?.Value;
                modData.usrcambio = usuariocambio;

                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "editarUsuarioMC";

                using (HttpClient httpClient = new HttpClient())
                {
                    var datos = JsonSerializer.Serialize(modData);
                    var contenido = new StringContent(datos, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync(URL, contenido);

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
        
        [HttpPost]
        public async Task<JsonResult> EditarRol(infoRolEditar modData)
        {
            Debug.WriteLine(modData.ToString());
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "editarRolMC";

                using (HttpClient httpClient = new HttpClient())
                {
                    var datos = JsonSerializer.Serialize(modData);
                    var contenido = new StringContent(datos, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync(URL, contenido);

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

        [HttpPost]
        public async Task<JsonResult> EditarPaqueteria(infoPaqueteriaEditar modData)
        {
            Debug.WriteLine(modData.ToString());
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "editarPaqueteriaMC";

                using (HttpClient httpClient = new HttpClient())
                {
                    var datos = JsonSerializer.Serialize(modData);
                    var contenido = new StringContent(datos, Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync(URL, contenido);

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


        /* ELIMINACIÓN DE USUARIOS / ROLES / PAQUETERIAS */
        [HttpPost]
        public async Task<JsonResult> EliminarUsuario(int id_usuario)
        {
            try
            {
                Debug.WriteLine("ID de usuario a eliminar: " + id_usuario);
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "eliminarUsuarioMC/"+ id_usuario;

                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync(URL);

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
                        return Json(new { success = false, errorMensaje });

                    }
                }
            }
            catch (Exception ex)
            {
                // Verifica si el mensaje de error contiene información sobre la conexión
                if (ex.Message.Contains("No se puede establecer una conexión") ||
                    ex.Message.Contains("el equipo de destino denegó expresamente dicha conexión"))
                {
                    return Json(new { success = false, errorMensaje = "No se pudo establecer conexión con el servidor. Por favor, verifica tu conexión a Internet o intenta más tarde." });
                }

                // Para otros errores, puedes retornar un mensaje genérico
                return Json(new { success = false, errorMensaje = "Ocurrió un error al procesar la solicitud. Intente nuevamente, si el inconveniente persiste contacte a soporte." });
            }
        }

        [HttpPost]
        public async Task<JsonResult> EliminarRol(int id_rol)
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "eliminarRolMC/" + id_rol;

                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync(URL);

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
                        return Json(new { success = false, errorMensaje });

                    }
                }
            }
            catch (Exception ex)
            {
                // Verifica si el mensaje de error contiene información sobre la conexión
                if (ex.Message.Contains("No se puede establecer una conexión") ||
                    ex.Message.Contains("el equipo de destino denegó expresamente dicha conexión"))
                {
                    return Json(new { success = false, errorMensaje = "No se pudo establecer conexión con el servidor. Por favor, verifica tu conexión a Internet o intenta más tarde." });
                }

                // Para otros errores, puedes retornar un mensaje genérico
                return Json(new { success = false, errorMensaje = "Ocurrió un error al procesar la solicitud. Intente nuevamente, si el inconveniente persiste contacte a soporte." });
            }
        }

        [HttpPost]
        public async Task<JsonResult> EliminarPaqueteria(int id_paqueteria)
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "eliminarPaqueteriaMC/" + id_paqueteria;

                using (HttpClient httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync(URL);

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
                        return Json(new { success = false, errorMensaje });

                    }
                }
            }
            catch (Exception ex)
            {
                // Verifica si el mensaje de error contiene información sobre la conexión
                if (ex.Message.Contains("No se puede establecer una conexión") ||
                    ex.Message.Contains("el equipo de destino denegó expresamente dicha conexión"))
                {
                    return Json(new { success = false, errorMensaje = "No se pudo establecer conexión con el servidor. Por favor, verifica tu conexión a Internet o intenta más tarde." });
                }

                // Para otros errores, puedes retornar un mensaje genérico
                return Json(new { success = false, errorMensaje = "Ocurrió un error al procesar la solicitud. Intente nuevamente, si el inconveniente persiste contacte a soporte." });
            }
        }

    }
}
