﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using ServiciosMC.Mcreativos.Clases;
using Microsoft.Extensions.Logging;
using ServiciosMC.Models;
using ServiciosMC.Helpers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;

namespace ServiciosMC.Controllers


{
    //[Authorize(Policy = "USUARIO_ADMIN")]
    [Authorize(Policy = "USUARIO_MULTIPLE")]
    public class HomeController : Controller
    {
        private readonly IConfiguration config;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration Iconfig)
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
        public JsonResult obtengoUsuario()
        {
            Helper helper = new Helper();
            LoginViewModel login = helper.Usuario(HttpContext);
            return Json(login.Usuario);

        }

        [HttpPost]
        public JsonResult obtenerPedido(String folio)
        {
            Debug.WriteLine("Ingresa a obtenerPedido: " + folio);
            //Para obtener el usuario que está logeado
            //Helper helper = new Helper();
            //LoginViewModel login = helper.Usuario(HttpContext);
            //String usuario = login.Usuario;
            ResultadoPedidoModel datosRespuesta = new ResultadoPedidoModel();
            infoPedido datosPedido = new infoPedido();

            String xml = @"<CONSULTAFOLIO><FOLIO>" + folio + "</FOLIO></CONSULTAFOLIO>";

            try
            {
                WSMCCONSULTAS.WSpedidosClient obtenerPedido = new WSMCCONSULTAS.WSpedidosClient(WSMCCONSULTAS.WSpedidosClient.EndpointConfiguration.WSpedidosPort, Helper.config.GetSection("Servicios:WSMCCONSULTA").Value);
                string resultadoConsultaWS = obtenerPedido.validaFolio(xml);

                if (!String.IsNullOrEmpty(resultadoConsultaWS.Trim()))
                {
                    try
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(RESPUESTACONSULTAFOLIO.RESPUESTA));
                        using (StringReader reader = new StringReader(resultadoConsultaWS))
                        {
                            var resultado = (RESPUESTACONSULTAFOLIO.RESPUESTA)serializer.Deserialize(reader);

                            if (resultado.Codigo.Equals("200"))
                            {
                                datosRespuesta.existeError = false;
                                datosRespuesta.existenDatos = true;

                                infoPedido informacion = new infoPedido();
                                informacion.folio = resultado.Pedido.Folio;
                                informacion.fecha = resultado.Pedido.Fecha;
                                informacion.cajero = resultado.Pedido.Cajero;
                                informacion.cliente = resultado.Pedido.Cliente;
                                informacion.total = resultado.Pedido.Total;
                                informacion.pago = resultado.Pedido.Pago;
                                informacion.cambio = resultado.Pedido.Cambio;
                                informacion.estatus = resultado.Pedido.Estatus;
                                datosRespuesta.infoPedido = informacion;
                            }
                        }
                    }
                    catch (Exception x)
                    {
                        Helpers.Helper.Log("Error al obtener datos: " + x.Message);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return Json(datosRespuesta);
        }


        [HttpPost]
        public async Task<JsonResult> ingresarProduccion(infoIngreso pedidoData)
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON")+ "ingresoPedidoMC";
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

        [HttpPost]
        public async Task<JsonResult> listaPedidos(infoConsultaPedidos usrData)
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


        /*Obtiene lista de pilotos ACTIVOS*/
        [HttpPost]
        public async Task<JsonResult> listaPilotos()
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "obtengoPilotosMC";

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

        /*Obtiene toda la lista de pilotos de la base de datos*/
        [HttpPost]
        public async Task<JsonResult> consultaPilotos()
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "consultaPilotosMC";

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

        /*Obtiene todas las empresas de paquetería de la base de datos*/
        [HttpPost]
        public async Task<JsonResult> consultaPaqueterias()
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











        [HttpPost]
        public async Task<JsonResult> cambioEstadoPedido(infoCambioPedido pedidoData)
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "cambioEstadoPedidoMC";
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





