using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ServiciosMC.Mcreativos.Clases;
using ServiciosMC.Helpers;
using ServiciosMC.Models;
using System.ServiceModel;

namespace ServiciosMC.MaterialesCreativos
{
    public class Autenticacion
    {
        private ResultadoViewModel resultado = new ResultadoViewModel();

        public Autenticacion()
        {
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
                    Helpers.Helper.LogXML(validacion.Body.datos, DateTime.Now.ToString("yyyyMMddHH") + login.Usuario);
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
                            Debug.WriteLine("----------------------");

                            if (test.VALIDACREDENCIALES.RESPUESTA.CODIGO == "200")
                            {
                                resultado.Estado = true;
                                resultado.Mensaje = test.VALIDACREDENCIALES.RESPUESTA.MENSAJE;
                                resultado.Tipo = test.VALIDACREDENCIALES.RESPUESTA.TIPO;
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

    }
}
