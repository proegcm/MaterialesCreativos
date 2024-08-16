using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RESPUESTACLIENTECOD
{
 
    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTA
    {
        [XmlElement(ElementName = "CODIGO")]
        public String CODIGO { get; set; }

        [XmlElement(ElementName = "DESCRIPCION")]
        public string DESCRIPCION { get; set; }
    }

    [XmlRoot(ElementName = "VALIDACREDENCIALES")]
    public class VALIDACREDENCIALES
    {
        [XmlElement(ElementName = "RESPUESTA")]
        public RESPUESTA RESPUESTA { get; set; }
    }


    [XmlRoot(ElementName = "RESPGCONSULTAWS")]
    public class RESPGCONSULTAWS
    {
        [XmlElement(ElementName = "VALIDACREDENCIALES")]
        public VALIDACREDENCIALES VALIDACREDENCIALES { get; set; }

    }

}
