using Microsoft.AspNetCore.Authorization;
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



namespace ServiciosMC.Controllers


{
    [Authorize(Policy = "USUARIO_ADMIN")]
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
        public async Task<JsonResult> IngresoPedido(infoIngreso pedidoData)
        {
            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON");
                var prueba = "";
                using (HttpClient httpClient = new HttpClient())
                {
                    var datos = JsonSerializer.Serialize(pedidoData);
                    var contenido = new StringContent(datos, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(URL, contenido);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        prueba = responseBody;
                        return Json(new { success = true, respuesta = prueba });

                    }
                    else
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        string errorMensaje = responseBody;
                        Debug.WriteLine("Código:"+errorMensaje);
                        return Json(new { success = false, error = errorMensaje });
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





