using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.OBTENERSEGURO
{
    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTAPORCENTAJESEGURO
    {
        [XmlElement(ElementName = "SEGUROOBTENIDO")]
        public string codigorespuesta { get; set; }
        [XmlElement(ElementName = "SEGURO")]
        public string montoseguro { get; set; }
        [XmlElement(ElementName = "MUESTRASEGURO")]
        public string muestraseguro { get; set; }
    }
}
