using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RespuestaValidacionDoc
{

    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTAVALIDACIONDOC
    {

        [XmlElement(ElementName = "TIPO")]
        public string tipo { get; set; }

        [XmlElement(ElementName = "DATO")]
        public string dato { get; set; }

        [XmlElement(ElementName = "ESTADO")]
        public string estado { get; set; }

        [XmlElement(ElementName = "CODIGO")]
        public string codigo { get; set; }

        [XmlElement(ElementName = "MENSAJE")]
        public string mensaje { get; set; }
    }
}



