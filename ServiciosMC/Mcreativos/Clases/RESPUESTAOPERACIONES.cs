using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.ROPERACIONES
{
    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTAOPERACIONES
    {
        [XmlElement(ElementName = "NUMERO1")]
        public string numero1 { get; set; }

        [XmlElement(ElementName = "NUMERO2")]
        public string numero2 { get; set; }

        [XmlElement(ElementName = "RESULTADO")]
        public string resultado { get; set; }

    }
}
