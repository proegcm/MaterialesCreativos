using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class ClientePersonaCODModel
    {
        public string CargaImagen { get; set; }
        public String UsuarioLogeado { get; set; }
        //public string codAgencia { get; set; }
        public DatosPersona DatosPersona { get; set; }
        public RecepcionFacturas RecepcionFacturas { get; set; }
        public InfoTransferenciaBancaria InfoTransferenciaBancaria { get; set; }
        public List<ImagenClientePersona> imagenes { get; set; }
    }

    public class DatosPersona
    {
        public String NombreTitular { get; set; }
        public String Dpi { get; set; }
        public String NombreDPI { get; set; }
        public String NoPasaporte { get; set; }
        public String NombrePasaporte { get; set; }
        public String Extendido { get; set; }
        public String CorreoElectronico { get; set; }
        public String Direccion { get; set; }
        public String Telefono { get; set; }
        public String Celular { get; set; }
        public String Nit { get; set; }
        public String paginaFacebook { get; set; }
        public String paginaInstagram { get; set; }
        public String ActividadPrincipal { get; set; }

    }

    public class ImagenClientePersona
    {
        public string nombre { get; set; }
        public string baseImg { get; set; }
    }

}
