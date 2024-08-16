using System.Collections.Generic;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.VALIDARDOCUMENTO
{
    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTAVALIDACIONDOCUMENTO
    {
        [XmlElement(ElementName = "DATO")]
        public string dato { get; set; }
        [XmlElement(ElementName = "TIPO")]
        public string tipo { get; set; }
        [XmlElement(ElementName = "ESTADO")]
        public string estado { get; set; }
        [XmlElement(ElementName = "MENSAJE")]
        public string mensaje { get; set; }
    }
}
