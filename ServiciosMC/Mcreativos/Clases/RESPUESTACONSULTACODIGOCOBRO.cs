using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.tipoCodigoCobro
{
    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTACONSULTACODIGOCOBRO
    {
        [XmlElement(ElementName = "CODCOB")]
        public string CODCOB { get; set; }

        [XmlElement(ElementName = "TIPO")]
        public string TIPO { get; set; }
    }
}
