using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RespuestaReimpresionGuia
{
    [XmlRoot(ElementName = "RESPUESTAREIMPRESIONGUIA")]
    public class RESPUESTAREIMPRESIOGUIA
    {
        [XmlElement(ElementName = "NOGUIA")]
        public string NOGUIA { get; set; }

        [XmlElement(ElementName = "RESPUESTA")]
        public string RESPUESTA { get; set; }

        [XmlElement(ElementName = "DESCRIPCION")]
        public string DESCRIPCION { get; set; }

        [XmlElement(ElementName = "URLNOGUIA")]
        public string URLNOGUIA { get; set; }

    }
}
