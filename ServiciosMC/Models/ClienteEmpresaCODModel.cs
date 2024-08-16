using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class ClienteEmpresaCODModel
    {
        public string CargaImagen { get; set; }
        public String UsuarioLogeado { get; set; }
        //public string codAgencia { get; set; }
        public DatosEmpresa DatosEmpresa { get; set; }
        public ResponsablesDespachoCOD ResponsablesDespachoCOD { get; set; }
        public RecepcionFacturas RecepcionFacturas { get; set; }
        public InfoTransferenciaBancaria InfoTransferenciaBancaria { get; set; }
        public List<ImagenClienteEmpresa> imagenes { get; set; }
    }

    public class DatosEmpresa {
        public String NombreTitular { get; set; }
        public String NombreComercial { get; set; }
        public String NitEmpresa { get; set; }
        public String PatenteComercio { get; set; }
        public String PatenteSociedad { get; set; }
        public String DireccionEmpresa { get; set; }
        public String TelefonoEmpresa { get; set; }
        public String ActividadPrincipal { get; set; }
        public String paginaFacebook { get; set; }
        public String paginaInstagram { get; set; }
        public String noDPI { get; set; }
        public String NombreDPI { get; set; }
        public String NoPasaporte { get; set; }
        public String NombrePasaporte { get; set; }
    }

    public class ResponsablesDespachoCOD
    {
        public String PersonaEncargada1 { get; set; }
        public String PersonaEncargadaCel1 {get;set;}
        public String PersonaEncargadaEmail1 {get;set;}

    }

    public class RecepcionFacturas
    { 
        public String NombreEncargadoRecepcion { get; set; }
        public String DepartamentoRecepcion { get; set; }
        public String DireccionRecepcion { get; set; }
        public String CorreoRecepcionFacturas { get; set; }
        public String TelefonoRecepcion { get; set; }
        public String ExtRecepcion { get; set; }
        public String FechaEmisionFacturaRecepcion { get; set; }
    }

    public class InfoTransferenciaBancaria
    {
        public string NombreCuenta { get; set; }
        public string NumeroCuenta { get; set; }
        public string TipoCuenta { get; set; }
        public string Banco { get; set; }
        public string ContactoResponsable { get; set; }
        public string CorreoElectronicoInfoBancaria { get; set; }
        public string EmisionFactura { get; set; }
        public string Puesto { get; set; }
        public string TelefonoInfoBancaria { get; set; }
        public string ExtInfoBancaria { get; set; }

    }

    public class ImagenClienteEmpresa
    {
        public string nombre { get; set; }
        public string baseImg { get; set; }
    }

}
