using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ServiciosMC.Mcreativos.Clases.RDETALLE
{
    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTADETALLEFACT
    {
        [XmlElement(ElementName = "IDF")]
        public string id_factura { get; set; }
        [XmlElement(ElementName = "IDDETALLE")]
        public string id_detalle { get; set; }
        [XmlElement(ElementName = "PRODUCTO")]
        public string producto { get; set; }
        [XmlElement(ElementName = "CANTIDAD")]
        public string cantidad { get; set; }
        [XmlElement(ElementName = "PRECIO")]
        public string valor_unitario { get; set; }
        [XmlElement(ElementName = "TOTAL")]
        public string valor_total { get; set; }

    }
}
