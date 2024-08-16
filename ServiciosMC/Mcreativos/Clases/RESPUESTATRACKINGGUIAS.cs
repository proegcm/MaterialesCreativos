using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RespuestaTrackingGuia
{
    [XmlRoot(ElementName = "RESPUESTATRACKINGGUIAS")]
    public class RESPUESTATRACKINGGUIAS
    {
        [XmlElement(ElementName = "NOGUIA")]
        public string NOGUIA { get; set; }

        [XmlElement(ElementName = "LLAVE")]
        public string LLAVE { get; set; }

        [XmlElement(ElementName = "CODIGO")]
        public string CODIGO { get; set; }

        [XmlElement(ElementName = "RESPUESTA")]
        public string RESPUESTA { get; set; }

        [XmlElement(ElementName = "INFORMACION")]
        public INFORMACION INFORMACION { get; set; }

        [XmlElement(ElementName = "TRACKING")]
        public TRACKING TRACKING { get; set; }

    }

    [XmlRoot(ElementName = "INFORMACION")]
    public class INFORMACION
    {
        [XmlElement(ElementName = "FRECUENCIAVISITAREMITENTE")]
        public string FRECUENCIAVISITAREMITENTE { get; set; }

        [XmlElement(ElementName = "FRECUENCIAVISITADESTINATARIO")]
        public string FRECUENCIAVISITADESTINATARIO { get; set; }

        [XmlElement(ElementName = "FECHACREACION")]
        public string FECHACREACION { get; set; }

        [XmlElement(ElementName = "DIRECCIONREMITENTE1")]
        public string DIRECCIONREMITENTE1 { get; set; }

        [XmlElement(ElementName = "DIRECCIONREMITENTE2")]
        public string DIRECCIONREMITENTE2 { get; set; }

        [XmlElement(ElementName = "NOMBREDESTINATARIO")]
        public string NOMBREDESTINATARIO { get; set; }

        [XmlElement(ElementName = "DIRECCIONDESTINATARIO1")]
        public string DIRECCIONDESTINATARIO1 { get; set; }

        [XmlElement(ElementName = "DIRECCIONDESTINATARIO2")]
        public string DIRECCIONDESTINATARIO2 { get; set; }

        [XmlElement(ElementName = "PTOORI")]
        public string PTOORI { get; set; }

        [XmlElement(ElementName = "PTODES")]
        public string PTODES { get; set; }

        [XmlElement(ElementName = "CODIGOCOBRO")]
        public string CODIGOCOBRO { get; set; }

        [XmlElement(ElementName = "TELEFONODESTINATARIO")]
        public string TELEFONODESTINATARIO { get; set; }

        [XmlElement(ElementName = "TARIFA")]
        public string TARIFA { get; set; }

        [XmlElement(ElementName = "PIEZAS")]
        public string PIEZAS { get; set; }

        [XmlElement(ElementName = "LCREDITO")]
        public string LCREDITO { get; set; }

        [XmlElement(ElementName = "LXCOBRAR")]
        public string LXCOBRAR { get; set; }

        [XmlElement(ElementName = "LPREPAGADA")]
        public string LPREPAGADA { get; set; }

        [XmlElement(ElementName = "LCONTADOFRECUENTE")]
        public string LCONTADOFRECUENTE { get; set; }

        [XmlElement(ElementName = "TELEFONOREMITENTE")]
        public string TELEFONOREMITENTE { get; set; }

        [XmlElement(ElementName = "HO")]
        public string HO { get; set; }

        [XmlElement(ElementName = "RA")]
        public string RA { get; set; }

        [XmlElement(ElementName = "RECIBIO")]
        public string RECIBIO { get; set; }

        [XmlElement(ElementName = "CEDULA")]
        public string CEDULA { get; set; }

        [XmlElement(ElementName = "FECHA")]
        public string FECHA { get; set; }

        [XmlElement(ElementName = "HORA")]
        public string HORA { get; set; }

        [XmlElement(ElementName = "SERIEFACTURA")]
        public string SERIEFACTURA { get; set; }

        [XmlElement(ElementName = "FACTURA")]
        public string FACTURA { get; set; }

        [XmlElement(ElementName = "RECOGEOFICINA")]
        public string RECOGEOFICINA { get; set; }

        [XmlElement(ElementName = "COBEX")]
        public string COBEX { get; set; }

        [XmlElement(ElementName = "CODIGODESTINATARIO")]
        public string CODIGODESTINATARIO { get; set; }

        [XmlElement(ElementName = "CODIGOREMITENTE")]
        public string CODIGOREMITENTE { get; set; }

        [XmlElement(ElementName = "CODVALORACOBRAR")]
        public string CODVALORACOBRAR { get; set; }

        [XmlElement(ElementName = "CODLIQUIDADO")]
        public string CODLIQUIDADO { get; set; }
        [XmlElement(ElementName = "CODLIQUIDADOFECHA")]
        public string CODLIQUIDADOFECHA { get; set; }


        [XmlElement(ElementName = "ESTADOIMN")]
        public string ESTADOIMN { get; set; }

        [XmlElement(ElementName = "FECHAENTREGAIMN")]
        public string FECHAENTREGAIMN { get; set; }

        [XmlElement(ElementName = "ESTADO")]
        public string ESTADO { get; set; }

        [XmlElement(ElementName = "LLAVECLIENTE")]
        public string LLAVECLIENTE { get; set; }

        [XmlElement(ElementName = "NOGUIA")]
        public string NOGUIA { get; set; }

        [XmlElement(ElementName = "MNCPORI")]
        public string MNCPORI { get; set; }

        [XmlElement(ElementName = "MNCPDES")]
        public string MNCPDES { get; set; }

        [XmlElement(ElementName = "NOMBREREMITENTE")]
        public string NOMBREREMITENTE { get; set; }
    }

    [XmlRoot(ElementName = "TRACKING")]
    public class TRACKING
    {
        [XmlElement(ElementName = "MOVIMIENTO")]
        public List<MOVIMIENTO> MOVIMIENTO { get; set; }
    }

    [XmlRoot(ElementName = "MOVIMIENTO")]
    public class MOVIMIENTO
    {
        [XmlElement(ElementName = "FECHAT")]
        public string FECHAT { get; set; }

        [XmlElement(ElementName = "HORAT")]
        public string HORAT { get; set; }

        [XmlElement(ElementName = "ESTADOT")]
        public string ESTADOT { get; set; }

        [XmlElement(ElementName = "RUTAT")]
        public string RUTAT { get; set; }

        [XmlElement(ElementName = "MOVIMIENTOT")]
        public string MOVIMIENTOT { get; set; }

        [XmlElement(ElementName = "NOGUIAT")]
        public string NOGUIAT { get; set; }

        [XmlElement(ElementName = "DESCRIPCIONT")]
        public string DESCRIPCIONT { get; set; }

        [XmlElement(ElementName = "POS")]
        public string POS { get; set; }

    }

}
