using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases
{
    public class RESPUESTABOLETAWS
    {
        [XmlElement(ElementName = "CODIGO")]
        public string Codigo { get; set; }

        [XmlElement(ElementName = "ESTADO")]
        public string Estado { get; set; }

        [XmlElement(ElementName = "MENSAJE")]
        public string Mensaje { get; set; }
    }
}
