using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RESPUESTACLIENTECODCOB
{
    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTACLIENTECODCOB
    {
        [XmlElement(ElementName = "CODIGO")]
        public String CODIGO { get; set; }

        [XmlElement(ElementName = "DESCRIPCION")]
        public String DESCRIPCION { get; set; }

        [XmlElement(ElementName = "CODCOB")]
        public String CODCOB { get; set; }
    }
}
