using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RESRECUPERACIONCONTRA
{

    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESRECUPERACIONCONTRA
    {
        [XmlElement(ElementName = "CODIGO")]
        public String CODIGO { get; set; }

        [XmlElement(ElementName = "DESCRIPCION")]
        public String DESCRIPCION { get; set; }

        [XmlElement(ElementName = "MENSAJE")]
        public String MENSAJE { get; set; }

    }
}
