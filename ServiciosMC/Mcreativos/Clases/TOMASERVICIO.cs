using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases
{

    [XmlRoot(ElementName = "LINEA_DETALLE_GUIA")]
    public class LINEADETALLEGUIA
    {

        [XmlElement(ElementName = "PIEZAS_DETALLE")]
        public int PIEZASDETALLE { get; set; }

        [XmlElement(ElementName = "TIPO_ENVIO_DETALLE")]
        public int TIPOENVIODETALLE { get; set; }

        [XmlElement(ElementName = "PESO_DETALLE")]
        public decimal PESODETALLE { get; set; }
    }

    [XmlRoot(ElementName = "DETALLE_GUIA")]
    public class DETALLEGUIA
    {

        [XmlElement(ElementName = "LINEA_DETALLE_GUIA")]
        public List<LINEADETALLEGUIA> LINEADETALLEGUIA { get; set; }
    }

    [XmlRoot(ElementName = "GUIA")]
    public class GUIA
    {

        [XmlElement(ElementName = "LLAVE_CLIENTE")]
        public string LLAVECLIENTE { get; set; }

        [XmlElement(ElementName = "COD_VALORACOBRAR")]
        public string CODVALORACOBRAR { get; set; }

        [XmlElement(ElementName = "SEABREPAQUETE")]
        public string SEABREPAQUETE { get; set; }

        [XmlElement(ElementName = "CODIGO_COBRO_GUIA")]
        public string CODIGOCOBROGUIA { get; set; }

        [XmlElement(ElementName = "NOMBRE_DESTINATARIO")]
        public string NOMBREDESTINATARIO { get; set; }


        [XmlElement(ElementName = "DECLARADO")]
        public string DECLARADO { get; set; }

        [XmlElement(ElementName = "SEGURO")]
        public string SEGURO { get; set; }

        [XmlElement(ElementName = "PAGO_CONTADO_SEGURO")]
        public string PAGO_CONTADO_SEGURO { get; set; }



        [XmlElement(ElementName = "TELEFONO_DESTINATARIO")]
        public string TELEFONODESTINATARIO { get; set; }

        [XmlElement(ElementName = "DIRECCION_DESTINATARIO")]
        public string DIRECCIONDESTINATARIO { get; set; }

        [XmlElement(ElementName = "MUNICIPIO_DESTINO")]
        public string MUNICIPIODESTINO { get; set; }

        [XmlElement(ElementName = "PUNTO_DESTINO")]
        public string PUNTODESTINO { get; set; }

        [XmlElement(ElementName = "DESCRIPCION_ENVIO")]
        public string DESCRIPCIONENVIO { get; set; }

        [XmlElement(ElementName = "OBSERVACIONES")]
        public string OBSERVACIONES { get; set; }

        [XmlElement(ElementName = "RECOGE_OFICINA")]



        public string RECOGEOFICINA { get; set; }

        [XmlElement(ElementName = "CODDESTINO")]
        public string CODDESTINO { get; set; }

        [XmlElement(ElementName = "DETALLE_GUIA")]
        public DETALLEGUIA DETALLEGUIA { get; set; }


        [XmlElement(ElementName = "OBSERVACIONES_ENTREGA")]
        public string OBSERVACIONES_ENTREGA { get; set; }


    }

    [XmlRoot(ElementName = "SERVICIO")]
    public class SERVICIO
    {



        [XmlElement(ElementName = "CONTACTO")]
        public string CONTACTO { get; set; }

        [XmlElement(ElementName = "TIPO_USUARIO")]
        public string TIPOUSUARIO { get; set; }

        [XmlElement(ElementName = "NOMBRE_REMITENTE")]
        public string NOMBREREMITENTE { get; set; }

        [XmlElement(ElementName = "TELEFONO_REMITENTE")]
        public string TELEFONOREMITENTE { get; set; }

        [XmlElement(ElementName = "DIRECCION_REMITENTE")]
        public string DIRECCIONREMITENTE { get; set; }

        [XmlElement(ElementName = "MUNICIPIO_ORIGEN")]
        public string MUNICIPIOORIGEN { get; set; }

        [XmlElement(ElementName = "PUNTO_ORIGEN")]
        public string PUNTOORIGEN { get; set; }

        [XmlElement(ElementName = "ESTA_LISTO")]
        public string ESTALISTO { get; set; }

        [XmlElement(ElementName = "CODORIGEN")]
        public string CODORIGEN { get; set; }

        [XmlElement(ElementName = "GUIA")]
        public GUIA GUIA { get; set; }
    }

    [XmlRoot(ElementName = "TOMA_SERVICIO")]
    public class TOMASERVICIO
    {

        [XmlElement(ElementName = "USUARIO")]
        public string USUARIO { get; set; }

        [XmlElement(ElementName = "PASSWORD")]
        public string PASSWORD { get; set; }

        [XmlElement(ElementName = "CODIGO_COBRO")]
        public string CODIGOCOBRO { get; set; }

        [XmlElement(ElementName = "SERVICIO")]
        public SERVICIO SERVICIO { get; set; }
    }


}
