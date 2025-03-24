using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ServiciosMC.Mcreativos.Clases;
using ServiciosMC.Helpers;
using ServiciosMC.Models;
using System.ServiceModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace ServiciosMC.MaterialesCreativos
{
    public class Autenticacion
    {
        private ResultadoViewModel resultado = new ResultadoViewModel();
        private readonly IConfiguration config;
        public Autenticacion(IConfiguration configuration)
        {
            config = configuration;
            resultado.Estado = false;
            resultado.Mensaje = "Usuario no autenticado.";
        }

        public ResultadoViewModel ValidarCredenciales(Models.LoginViewModel login)
        {
            Debug.WriteLine("en ValidarCredenciales -> "+login.Usuario+"-"+login.Password);
            try
            {
                WSMCLOGIN.WSLoginClient ce = new WSMCLOGIN.WSLoginClient(WSMCLOGIN.WSLoginClient.EndpointConfiguration.WSLoginPort, Helper.config.GetSection("Servicios:WSMCLOGIN").Value);
                WSMCLOGIN.validaCredencialesRequest validacion = new WSMCLOGIN.validaCredencialesRequest();
                validacion.Body = new WSMCLOGIN.validaCredencialesRequestBody();
                validacion.Body.datos = @"<LOGIN><USR>"+login.Usuario+ "</USR><PSSWRD>" + login.Password + "</PSSWRD></LOGIN>";

                try
                {
                    //Helpers.Helper.LogXML(validacion.Body.datos, DateTime.Now.ToString("yyyyMMddHH") + login.Usuario);
                    var response = ce.validaCredenciales(validacion.Body.datos);
                    Helpers.Helper.LogXML(response, DateTime.Now.ToString("yyyyMMddHH") + login.Usuario);
                    XmlDocument doc = new XmlDocument();
                    try
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(PORTALSERVICIOSMC));
                        using (StringReader reader = new StringReader(response))
                        {
                            var test = (PORTALSERVICIOSMC)serializer.Deserialize(reader);
                            Debug.WriteLine("-----> respuesta WS: ");
                            Debug.WriteLine(test.VALIDACREDENCIALES.RESPUESTA.CODIGO);
                            Debug.WriteLine(test.VALIDACREDENCIALES.RESPUESTA.MENSAJE);
                            Debug.WriteLine(test.VALIDACREDENCIALES.RESPUESTA.AUTORIZACION);
                            Debug.WriteLine(test.VALIDACREDENCIALES.RESPUESTA.TIPO);
                            Debug.WriteLine(test.VALIDACREDENCIALES.RESPUESTA.ID);
                            Debug.WriteLine("----------------------");

                            if (test.VALIDACREDENCIALES.RESPUESTA.CODIGO == "200")
                            {
                                resultado.Estado = true;
                                resultado.Mensaje = test.VALIDACREDENCIALES.RESPUESTA.MENSAJE;
                                resultado.Tipo = test.VALIDACREDENCIALES.RESPUESTA.TIPO;
                                resultado.ID = test.VALIDACREDENCIALES.RESPUESTA.ID;
                            }
                            else
                            {
                                resultado.Estado = false;
                                resultado.Mensaje = test.VALIDACREDENCIALES.RESPUESTA.MENSAJE;
                            }
                        }
                    }
                    catch (Exception x)
                    {
                        Helpers.Helper.Log("Error Autenticacion : " + x.Message);
                        //Error al parsear xml
                        this.resultado.Estado = false;
                        this.resultado.Mensaje = "Error al procesar la respuesta del servidor. Contacte al administrador.";
                    }

                }
                catch (EndpointNotFoundException ex)
                {
                    Helpers.Helper.Log("Error Autenticacion: " + ex.Message);
                    // Error de conexión al WebService
                    this.resultado.Estado = false;
                    this.resultado.Mensaje = "No se pudo conectar con el servidor. Por favor, verifica tu conexión a internet o contacta al administrador.";
                }
                catch (CommunicationException ex)
                {
                    Helpers.Helper.Log("Error Autenticacion: " + ex.Message);
                    // Error de comunicación
                    this.resultado.Estado = false;
                    this.resultado.Mensaje = "Error de comunicación con el servidor. Intenta nuevamente más tarde.";
                }
                catch (TimeoutException ex)
                {
                    Helpers.Helper.Log("Error Autenticacion: " + ex.Message);
                    // Error de tiempo de espera
                    this.resultado.Estado = false;
                    this.resultado.Mensaje = "El servidor no respondió a tiempo. Intenta nuevamente más tarde.";
                }
                catch (Exception e)
                {
                    Helpers.Helper.Log("Error Autenticacion: " + e.Message);
                    // Error general al consultar el método
                    this.resultado.Estado = false;
                    this.resultado.Mensaje = "Ocurrió un error al intentar autenticarse. Por favor, intenta nuevamente.";
                }

            }
            catch (Exception ex)
            {
                Helpers.Helper.Log("Error Total : " + ex.Message);
                this.resultado.Estado = false;
                this.resultado.Mensaje = "Ocurrió un error inesperado. Por favor, intenta nuevamente.";
            }

            return resultado;
        }


        [HttpPost]
        public async Task<ResultadoViewModel> ValidarCredencialesNuevo(Models.LoginViewModel loginC)
        {
            var resultado = new ResultadoViewModel();

            try
            {
                string URL = config.GetValue<string>("Servicios:API_PYTHON") + "LoginMC";

                var credenciales = new
                {
                    LOGIN = new
                    {
                        USR = loginC.Usuario,
                        PSSWRD = loginC.Password
                    }
                };

                using (HttpClient httpClient = new HttpClient())
                {
                    var datos = JsonSerializer.Serialize(credenciales);
                    var contenido = new StringContent(datos, Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync(URL, contenido);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseBody = await response.Content.ReadAsStringAsync();
                        try
                        {
                            var responseObject = JsonSerializer.Deserialize<AutorizacionResponse>(responseBody);

                            if (responseObject != null && responseObject.CODIGO == "200")
                            {
                                resultado.Estado = true;
                                resultado.Mensaje = responseObject.MENSAJE;
                                resultado.Tipo = responseObject.TIPO;
                                resultado.ID = responseObject.ID;
                                resultado.Nombre = responseObject.NOMBRE;
                            }
                            else
                            {
                                resultado.Estado = false;
                                resultado.Mensaje = responseObject?.MENSAJE ?? "Error de autenticación";
                            }
                        }
                        catch (JsonException ex)
                        {
                            Debug.WriteLine("Error de deserialización: " + ex.Message);
                            resultado.Estado = false;
                            resultado.Mensaje = "Error al procesar la respuesta del servidor.";
                        }
                    }
                    else
                    {
                        // Si la respuesta no es exitosa, intentamos obtener el mensaje del JSON
                        var responseBody = await response.Content.ReadAsStringAsync();
                        try
                        {
                            var responseObject = JsonSerializer.Deserialize<AutorizacionResponse>(responseBody);

                            // Si la respuesta tiene un mensaje de error definido, lo mostramos
                            if (responseObject != null && !string.IsNullOrEmpty(responseObject.MENSAJE))
                            {
                                resultado.Estado = false;
                                resultado.Mensaje = responseObject.MENSAJE;
                            }
                            else
                            {
                                switch (response.StatusCode)
                                {
                                    case HttpStatusCode.BadGateway:
                                        resultado.Mensaje = "Error de comunicación con el servidor. Intente nuevamente, si el inconveniente persiste contácte al administrador.";
                                        break;
                                    case HttpStatusCode.NotFound:
                                        resultado.Mensaje = "El servicio no está disponible en este momento. Contacte al administrador.";
                                        break;
                                    default:
                                        resultado.Mensaje = $"Error {response.StatusCode}: No se pudo autenticar. Intente más tarde.";
                                        break;
                                }
                            }
                        }
                        catch (JsonException ex)
                        {
                            Debug.WriteLine("Error de deserialización: " + ex.Message);
                            resultado.Estado = false;
                            resultado.Mensaje = "Error de comunicación con el servidor. Intente nuevamente, si el inconveniente persiste contácte al administrador.";
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error en ValidarCredencialesNuevo: " + ex.Message);
                resultado.Estado = false;
                resultado.Mensaje = "Ocurrió un error inesperado. Contacte al administrador.";
            }

            return resultado;
        }



    }
}
