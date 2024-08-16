using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RESREINICIOCONTRA
{
    [XmlRoot(ElementName = "RESPUESTAREINICIOCONTRA")]
    public class RESPUESTAREINICIOCONTRA
    {
        [XmlElement(ElementName = "USUARIO")]
        public string USUARIO { get; set; }

        [XmlElement(ElementName = "CODIGO")]
        public string CODIGO { get; set; }
    }

    [XmlRoot(ElementName = "VALIDARESPUESTA")]
    public class VALIDARESPUESTA
    {
        [XmlElement(ElementName = "RESPUESTAREINICIOCONTRA")]
        public RESPUESTAREINICIOCONTRA RESPUESTAREINICIOCONTRA { get; set; }
    }
}
