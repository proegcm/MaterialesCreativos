using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiciosMC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ServiciosMC.Helpers
{
    public class Helper
    {

        public static String Enviroment { get; set; }

        public static IConfigurationRoot config { get; set; }
        public LoginViewModel Usuario(HttpContext httpContext)
        {
            var usuario = httpContext.User.Identities.ToArray()[0].Claims.ToList().Where(x => x.Type == "Usuario").FirstOrDefault().Value;
            var Password = httpContext.User.Identities.ToArray()[0].Claims.ToList().Where(x => x.Type == "Password").FirstOrDefault().Value;

            LoginViewModel login = new LoginViewModel { Password = Password, Usuario = usuario };
            return login;
        }

        public static void Log(string contenido)
        {
            try
            {
                string pathOrigen = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Log");
                if (!Directory.Exists(pathOrigen))
                {
                    Directory.CreateDirectory(pathOrigen);
                }

                string nombreDia = DateTime.Now.ToString("yyyyMMdd");
                pathOrigen = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Log/" + nombreDia);
                if (!Directory.Exists(pathOrigen))
                {
                    Directory.CreateDirectory(pathOrigen);
                }

                pathOrigen = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Log/" + nombreDia + "/" + nombreDia + ".log");
                if (!File.Exists(pathOrigen))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(pathOrigen))
                    {
                        sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        sw.Write(" ");
                        sw.WriteLine(contenido);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(pathOrigen))
                    {
                        sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        sw.Write(" ");
                        sw.WriteLine(contenido);
                    }
                }
            }
            catch (Exception)
            {
            }
        }


        public static void LogXML(string contenido, string prefixNombre)
        {
            try
            {
                string pathOrigen = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Log/XML/");
                if (!Directory.Exists(pathOrigen))
                {
                    Directory.CreateDirectory(pathOrigen);
                }

                string nombreDia = DateTime.Now.ToString("yyyyMMdd");
                pathOrigen = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Log/XML/" + nombreDia);
                if (!Directory.Exists(pathOrigen))
                {
                    Directory.CreateDirectory(pathOrigen);
                }

                pathOrigen = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Log/XML/" + nombreDia + "/" + prefixNombre + nombreDia + ".log");
                if (!File.Exists(pathOrigen))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(pathOrigen))
                    {
                        sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        sw.Write(" ");
                        sw.WriteLine(contenido);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(pathOrigen))
                    {
                        sw.Write(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        sw.Write(" ");
                        sw.WriteLine(contenido);
                    }
                }
            }
            catch (Exception)
            {
            }
        }



    }
}
