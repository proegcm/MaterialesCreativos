using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.ServiceModel;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ServiciosMC.Helpers;
using ServiciosMC.Models;

namespace ServiciosMC.Controllers
{
    [Authorize(Policy = "USUARIO_MULTIPLE")]
    public class PrincipalController : Controller
    {
        private readonly IConfiguration config;
        private readonly ILogger<PrincipalController> _logger;

        public PrincipalController(ILogger<PrincipalController> logger, IConfiguration Iconfig)
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
        public JsonResult ObtengoUsuario()
        {
            Helper helper = new();
            LoginViewModel login = helper.Usuario(HttpContext);
            return Json(login.Usuario);

        }

        [HttpPost]
        public JsonResult ObtenerPedido(String folio)
        {
            Debug.WriteLine("Ingresa a obtenerPedido: " + folio);
            ResultadoPedidoModel datosRespuesta = new();
            try
            {
                XElement datosXML = new("CONSULTAPEDIDO", new XElement("FOLIO", folio));

                Debug.WriteLine("datosXML: " + datosXML);

                string servicioUrl = Helper.config.GetSection("Servicios:WSMCCONSULTA").Value;
                Debug.WriteLine("URL del servicio: " + servicioUrl);

                //string resultadoConsultaWS = @"{""CODIGO"":""200"",""MENSAJE"":""OK"",""PEDIDO"":{""idTicket"":32204,""folio"":25225,""fecha"":""Mar 20, 2025 2:02:55 PM"",""cajero"":""Karen"",""cliente"":""Moises Nistal"",""total"":168.0100,""pago"":168.0100,""cambio"":0.0000,""estatus"":""ACTIVO"",""detallePedido"":[{""producto"":""Guatex X Cobrar"",""cantidad"":1,""precio"":0.0100},{""producto"":""Yda Text Mate #2 Blanco"",""cantidad"":1,""precio"":48.0000},{""producto"":""Yda Text Mate #22 Dorado"",""cantidad"":1,""precio"":48.0000},{""producto"":""Yarda MC Subli #143"",""cantidad"":1,""precio"":72.0000}]}}";
                WSMCCONSULTAS.WSpedidosClient obtenerPedido = new(WSMCCONSULTAS.WSpedidosClient.EndpointConfiguration.WSpedidosPort, servicioUrl);
                string resultadoConsultaWS = obtenerPedido.validaFolio(datosXML.ToString());

                Debug.WriteLine("resultadoConsultaWS");
                Debug.WriteLine(resultadoConsultaWS);
                Debug.WriteLine("------------------------");

                if (!String.IsNullOrWhiteSpace(resultadoConsultaWS))
                {
                    try
                    {
                        var resultado = JsonSerializer.Deserialize<RespuestaPedido>(resultadoConsultaWS);

                        if (resultado != null)
                        {
                            Debug.WriteLine("Datos JSON: " + resultado);

                            if (resultado.CODIGO.Equals("200"))
                            {
                                datosRespuesta.existeError = false;
                                datosRespuesta.existenDatos = true;

                                datosRespuesta.infoPedido = new InfoPedido
                                {
                                    idTicket = resultado.PEDIDO.idTicket,
                                    folio = resultado.PEDIDO.folio,
                                    fecha = resultado.PEDIDO.fecha,
                                    cajero = resultado.PEDIDO.cajero,
                                    cliente = resultado.PEDIDO.cliente,
                                    total = resultado.PEDIDO.total,
                                    pago = resultado.PEDIDO.pago,
                                    cambio = resultado.PEDIDO.cambio,
                                    estatus = resultado.PEDIDO.estatus,
                                    detallePedido = resultado.PEDIDO.detallePedido.Select(item => new ArticulosPedido
                                    {
                                        producto = item.producto,
                                        cantidad = item.cantidad,
                                        precio = item.precio
                                    }).ToList() ?? new List<ArticulosPedido>() // Evitar null
                                };
                            }
                            else
                            {
                                datosRespuesta.existeError = true;
                                datosRespuesta.existenDatos = false;
                            }
                        }
                        else
                        {
                            Debug.WriteLine("Deserialización fallida. El objeto resultado es null.");
                        }


                    }
                    catch (Exception x)
                    {
                        Helpers.Helper.Log("Error al obtener datos: " + x.Message);
                        return Json(new
                        {
                            existeError = true,
                            existenDatos = false,
                            mensajeError = "Ocurrió un error al procesar la información del pedido."
                        });
                    }
                }
                else
                {
                    return Json(new { existeError = true, existenDatos = false, mensajeError = "No se recibieron datos del servicio." });
                }
            }
            catch (EndpointNotFoundException ex)
            {
                Helpers.Helper.Log("Error de conexión al servicio: " + ex.Message);
                return Json(new
                {
                    existeError = true,
                    existenDatos = false,
                    mensajeError = "No se pudo conectar con el servicio de pedidos. Por favor, verifique su conexión o intente de nuevo."
                });
            }
            catch (Exception ex)
            {
                // Error genérico
                Helpers.Helper.Log("Error inesperado: " + ex.Message);
                return Json(new
                {
                    existeError = true,
                    existenDatos = false,
                    mensajeError = "Ocurrió un error inesperado. Intente nuevamente."
                });
            }
            return Json(datosRespuesta);
        }


        [HttpPost]
        public JsonResult ObtenerPedidoCliente(String cliente, String fecha)
        {
            Debug.WriteLine("Ingresa a obtenerPedidoCliente: " + cliente + " - "+fecha);
            ResultadoPedidoModel datosRespuesta = new();
            try
            {
                XElement datosXML = new("CONSULTAPEDIDO", new XElement("CLIENTE", cliente), new XElement("FECHA", fecha));

                Debug.WriteLine("datosXML: " + datosXML);

                string servicioUrl = Helper.config.GetSection("Servicios:WSMCCONSULTA").Value;
                Debug.WriteLine("URL del servicio: " + servicioUrl);

                //string resultadoConsultaWS = @"{""CODIGO"":""200"",""MENSAJE"":""OK"",""PEDIDO"":{""idTicket"":32204,""folio"":25225,""fecha"":""Mar 20, 2025 2:02:55 PM"",""cajero"":""Karen"",""cliente"":""Moises Nistal"",""total"":168.0100,""pago"":168.0100,""cambio"":0.0000,""estatus"":""ACTIVO"",""detallePedido"":[{""producto"":""Guatex X Cobrar"",""cantidad"":1,""precio"":0.0100},{""producto"":""Yda Text Mate #2 Blanco"",""cantidad"":1,""precio"":48.0000},{""producto"":""Yda Text Mate #22 Dorado"",""cantidad"":1,""precio"":48.0000},{""producto"":""Yarda MC Subli #143"",""cantidad"":1,""precio"":72.0000}]}}";
                WSMCCONSULTAS.WSpedidosClient obtenerPedido = new(WSMCCONSULTAS.WSpedidosClient.EndpointConfiguration.WSpedidosPort, servicioUrl);
                string resultadoConsultaWS = obtenerPedido.validaCliente(datosXML.ToString());

                Debug.WriteLine("resultadoConsultaWS");
                Debug.WriteLine(resultadoConsultaWS);
                Debug.WriteLine("------------------------");

                if (!String.IsNullOrWhiteSpace(resultadoConsultaWS))
                {
                    try
                    {
                        var resultado = JsonSerializer.Deserialize<RespuestaPedido>(resultadoConsultaWS);

                        if (resultado != null)
                        {
                            Debug.WriteLine("Datos JSON: " + resultado);

                            if (resultado.CODIGO.Equals("200"))
                            {
                                datosRespuesta.existeError = false;
                                datosRespuesta.existenDatos = true;

                                datosRespuesta.infoPedido = new InfoPedido
                                {
                                    idTicket = resultado.PEDIDO.idTicket,
                                    folio = resultado.PEDIDO.folio,
                                    fecha = resultado.PEDIDO.fecha,
                                    cajero = resultado.PEDIDO.cajero,
                                    cliente = resultado.PEDIDO.cliente,
                                    total = resultado.PEDIDO.total,
                                    pago = resultado.PEDIDO.pago,
                                    cambio = resultado.PEDIDO.cambio,
                                    estatus = resultado.PEDIDO.estatus,
                                    detallePedido = resultado.PEDIDO.detallePedido.Select(item => new ArticulosPedido
                                    {
                                        producto = item.producto,
                                        cantidad = item.cantidad,
                                        precio = item.precio
                                    }).ToList() ?? new List<ArticulosPedido>() // Evitar null
                                };
                            }
                            else
                            {
                                datosRespuesta.existeError = true;
                                datosRespuesta.existenDatos = false;
                            }
                        }
                        else
                        {
                            Debug.WriteLine("Deserialización fallida. El objeto resultado es null.");
                        }


                    }
                    catch (Exception x)
                    {
                        Helpers.Helper.Log("Error al obtener datos: " + x.Message);
                        return Json(new
                        {
                            existeError = true,
                            existenDatos = false,
                            mensajeError = "Ocurrió un error al procesar la información del pedido."
                        });
                    }
                }
                else
                {
                    return Json(new { existeError = true, existenDatos = false, mensajeError = "No se recibieron datos del servicio." });
                }
            }
            catch (EndpointNotFoundException ex)
            {
                Helpers.Helper.Log("Error de conexión al servicio: " + ex.Message);
                return Json(new
                {
                    existeError = true,
                    existenDatos = false,
                    mensajeError = "No se pudo conectar con el servicio de pedidos. Por favor, verifique su conexión o intente de nuevo."
                });
            }
            catch (Exception ex)
            {
                // Error genérico
                Helpers.Helper.Log("Error inesperado: " + ex.Message);
                return Json(new
                {
                    existeError = true,
                    existenDatos = false,
                    mensajeError = "Ocurrió un error inesperado. Intente nuevamente."
                });
            }
            return Json(datosRespuesta);
        }


        [HttpPost]
        public JsonResult ObtenerClientes()
        {
            ResultadoClientesModel datosRespuesta = new();
            try
            {
                string servicioUrl = Helper.config.GetSection("Servicios:WSMCCONSULTA").Value;
                Debug.WriteLine("URL del servicio: " + servicioUrl);

                // Crear cliente del servicio
                WSMCCONSULTAS.WSpedidosClient obtenerClientes = new(WSMCCONSULTAS.WSpedidosClient.EndpointConfiguration.WSpedidosPort, servicioUrl);

                // Crear la solicitud vacía
                WSMCCONSULTAS.obtenerClientesRequest request = new WSMCCONSULTAS.obtenerClientesRequest(new WSMCCONSULTAS.obtenerClientesRequestBody());

                // Llamar al servicio correctamente
                WSMCCONSULTAS.obtenerClientesResponse response = obtenerClientes.obtenerClientes(request);

                // Obtener la respuesta en formato string
                string resultadoConsultaWS = response.Body.@return;

                // Imprimir resultados en consola
                Debug.WriteLine("resultadoConsultaWS");
                Debug.WriteLine(resultadoConsultaWS);
                Debug.WriteLine("------------------------");
                if (!String.IsNullOrWhiteSpace(resultadoConsultaWS))
                {
                    try
                    {
                        var resultado = JsonSerializer.Deserialize<RespuestaClientes>(resultadoConsultaWS);

                        if (resultado != null)
                        {
                            Debug.WriteLine("Datos JSON: " + resultado);

                            if (resultado.CODIGO.Equals("200"))
                            {
                                datosRespuesta.existeError = false;
                                datosRespuesta.existenDatos = true;

                                datosRespuesta.infoClientes = new InfoClientes
                                {
                                    listaClientes = resultado.CLIENTES.Select(item => new Cliente
                                    {
                                        nombre = item.nombre
                                    }).ToList() ?? new List<Cliente>() // Evitar null
                                };
                            }
                            else
                            {
                                datosRespuesta.existeError = true;
                                datosRespuesta.existenDatos = false;
                            }
                        }
                        else
                        {
                            Debug.WriteLine("Deserialización fallida. El objeto resultado es null.");
                        }


                    }
                    catch (Exception x)
                    {
                        Helpers.Helper.Log("Error al obtener datos: " + x.Message);
                        return Json(new
                        {
                            existeError = true,
                            existenDatos = false,
                            mensajeError = "Ocurrió un error al procesar la información del pedido."
                        });
                    }
                }
                else
                {
                    return Json(new { existeError = true, existenDatos = false, mensajeError = "No se recibieron datos del servicio." });
                }


            }
            catch (EndpointNotFoundException ex)
            {
                Helpers.Helper.Log("Error de conexión al servicio: " + ex.Message);
                return Json(new
                {
                    existeError = true,
                    existenDatos = false,
                    mensajeError = "No se pudo conectar con el servicio de pedidos. Por favor, verifique su conexión o intente de nuevo."
                });
            }
            catch (Exception ex)
            {
                // Error genérico
                Helpers.Helper.Log("Error inesperado: " + ex.Message);
                return Json(new
                {
                    existeError = true,
                    existenDatos = false,
                    mensajeError = "Ocurrió un error inesperado. Intente nuevamente."
                });
            }
            return Json(datosRespuesta);
        }

        [HttpPost]
        public async Task<JsonResult> IngresarProduccion(infoIngreso pedidoData)
        {
            try
            {
                Helper helper = new();
                LoginViewModel login = helper.Usuario(HttpContext);
                string usuarioLogin = login.Usuario;
                pedidoData.usuario = usuarioLogin;

                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "ingresoPedidoMC";

                using (HttpClient httpClient = new())
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
                        string errorMensaje = errorObject["error"];  // Acceder al valor de la clave "error"
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
        public async Task<JsonResult> ListaPedidosDash()
        {

            try
            {
                Helper helper = new();
                LoginViewModel login = helper.Usuario(HttpContext);
                string usuarioLogin = login.Usuario;

                infoConsultaPedidos usrData = new()
                {
                    infoUsuario = new infoUsuario
                    {
                        usuario = usuarioLogin
                    }
                };
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "obtengoPedidosDashboardMC";

                using (HttpClient httpClient = new())
                {

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
                return Json(new { success = false, errorMensaje = "Error al cargar los pedidos. Intente recargar la página de nuevo." });
            }
        }


        /*Obtiene lista de pilotos ACTIVOS*/
        [HttpPost]
        public async Task<JsonResult> ListaPilotos()
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "obtengoPilotosMC";

                using (HttpClient httpClient = new())
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

        /*Obtiene toda la lista de pilotos de la base de datos*/
        [HttpPost]
        public async Task<JsonResult> ConsultaPilotos()
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "consultaPilotosMC";

                using (HttpClient httpClient = new())
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

        /*Obtiene todas las empresas de paquetería de la base de datos*/
        [HttpPost]
        public async Task<JsonResult> ConsultaPaqueterias()
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "consultaPaqueteriasMC";

                using (HttpClient httpClient = new())
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
        public async Task<JsonResult> CambioEstadoPedido(infoCambioPedido pedidoData)
        {
            try
            {
                Helper helper = new();
                LoginViewModel login = helper.Usuario(HttpContext);
                string usuarioLogin = login.Usuario;
                pedidoData.usuario = usuarioLogin;

                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "cambioEstadoPedidoMC";
                using (HttpClient httpClient = new())
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
                        string errorMensaje = errorObject["error"];  // Acceder al valor de la clave "error"
                        Debug.WriteLine("Código:" + errorMensaje);
                        return Json(new { success = false, errorMensaje });

                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, respuesta = "Error al procesar los datos: " + ex.Message });
            }
        }
    }
}
