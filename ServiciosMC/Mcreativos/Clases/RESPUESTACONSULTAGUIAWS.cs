using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RespuestaConsultaGuia
{


    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTA
    {
        [XmlElement(ElementName = "CODIGO")]
        public String CODIGO { get; set; }

        [XmlElement(ElementName = "DESCRIPCION")]
        public string DESCRIPCION { get; set; }
    }

    [XmlRoot(ElementName = "INFOGUIA")]
    public class INFOGUIA
    {
        [XmlElement(ElementName = "GUIA")]
        public string guia { get; set; }

        [XmlElement(ElementName = "PESO")]
        public string peso { get; set; }

        [XmlElement(ElementName = "DETALLE_ENVIO")]
        public string detalle_envio { get; set; }

        [XmlElement(ElementName = "DEPARTAMENTO_DESTINO")]
        public string departamento_destino { get; set; }

        [XmlElement(ElementName = "MUNICIPIO_DESTINO")]
        public string municipio_destino { get; set; }

        [XmlElement(ElementName = "DESTINATARIO")]
        public string destinatario { get; set; }

        [XmlElement(ElementName = "FECHA_RECOLECCION")]
        public string fecha_recoleccion { get; set; }

        [XmlElement(ElementName = "FECHA_CREACION")]
        public string fecha_creacion { get; set; }

        [XmlElement(ElementName = "FECHA_ENTREGA")]
        public string fecha_entrega { get; set; }

        [XmlElement(ElementName = "FECHA_PAGO")]
        public string fecha_pago { get; set; }

        [XmlElement(ElementName = "NUMERO_DEPOSITO")]
        public string numero_deposito { get; set; }

        [XmlElement(ElementName = "VALOR_COD")]
        public string valor_cod { get; set; }

        [XmlElement(ElementName = "VALOR_SERVICIO")]
        public string valor_servicio { get; set; }

        [XmlElement(ElementName = "VALOR_ACREDITAR")]
        public string valor_acreditar { get; set; }

    }

    [XmlRoot(ElementName = "VALIDACREDENCIALES")]
    public class VALIDACREDENCIALES
    {
        [XmlElement(ElementName = "RESPUESTA")]
        public RESPUESTA RESPUESTA { get; set; }
    }

    [XmlRoot(ElementName = "GUIAS")]
    public class GUIAS
    {
        [XmlElement(ElementName = "INFOGUIA")]
        public List<INFOGUIA> INFOGUIA { get; set; }
    }

    [XmlRoot(ElementName = "RESPGCONSULTAWS")]
    public class RESPGCONSULTAWS
    {
        [XmlElement(ElementName = "VALIDACREDENCIALES")]
        public VALIDACREDENCIALES VALIDACREDENCIALES { get; set; }

        [XmlElement(ElementName = "GUIAS")]
        public GUIAS GUIAS { get; set; }

        [XmlElement(ElementName = "ES_COD")]
        public String esCod { get; set; }

        [XmlElement(ElementName = "CONTIENE_GUIAS_COD")]
        public String contiene_guias_cod { get; set; }
    }

}
