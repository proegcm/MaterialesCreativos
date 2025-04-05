using System;
using System.Diagnostics;
using ServiciosMC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace ServiciosMC.Mcreativos
{
    public class Autenticacion
    {
        private ResultadoViewModel resultado = new();
        private readonly IConfiguration config;
        public Autenticacion(IConfiguration configuration)
        {
            config = configuration;
            resultado.Estado = false;
            resultado.Mensaje = "Usuario no autenticado.";
        }

        [HttpPost]
        public async Task<ResultadoViewModel> ValidarCredencialesNuevo(LoginViewModel loginC)
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

                using (HttpClient httpClient = new())
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
                            Debug.WriteLine("Respuesta: " + responseObject);
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
                            Debug.WriteLine(">> Respuesta: ");
                            Debug.WriteLine(">> CODIGO: " + responseObject.CODIGO);
                            Debug.WriteLine(">> ID: " + responseObject.ID);
                            Debug.WriteLine(">> TIPO: " + responseObject.TIPO);
                            Debug.WriteLine(">> AUTORIZACION: " + responseObject.AUTORIZACION);
                            Debug.WriteLine(">> NOMBRE: " + responseObject.NOMBRE);
                            Debug.WriteLine(">> MENSAJE: " + responseObject.MENSAJE);
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
