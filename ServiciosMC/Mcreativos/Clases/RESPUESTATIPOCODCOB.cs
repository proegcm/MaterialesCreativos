using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.REPUESTA_ESCOD
{

    [XmlRoot(ElementName = "VALIDACREDENCIALES")]
    public class VALIDACREDENCIALES
    {
        [XmlElement(ElementName = "RESPUESTA")]
        public RESPUESTA RESPUESTA { get; set; }
    }
    public class RESPUESTA
    {

        [XmlElement(ElementName = "CODIGO")]
        public string CODIGO { get; set; }

        [XmlElement(ElementName = "DESCRIPCION")]
        public string DESCRIPCION { get; set; }
    }



    [XmlRoot(ElementName = "RESPGCONSULTAWS")]
    public class RESPGCONSULTAWS
    {
        [XmlElement(ElementName = "VALIDACREDENCIALES")]
        public VALIDACREDENCIALES VALIDACREDENCIALES { get; set; }

        [XmlElement(ElementName = "ES_COD")]
        public String es_cod { get; set; }
    }
}
