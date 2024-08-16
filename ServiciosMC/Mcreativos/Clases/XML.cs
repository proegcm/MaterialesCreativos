using System;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases
{
    public class XML
    {
    }


    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTA
    {

        [XmlElement(ElementName = "CODIGO")]
        public string CODIGO { get; set; }

        [XmlElement(ElementName = "MENSAJE")]
        public string MENSAJE { get; set; }

        [XmlElement(ElementName = "AUTORIZACION")]
        public Boolean AUTORIZACION { get; set; }

        [XmlElement(ElementName = "TIPO")]
        public string TIPO { get; set; }

    }



    [XmlRoot(ElementName = "VALIDACREDENCIALES")]
    public class VALIDACREDENCIALES
    {

        [XmlElement(ElementName = "RESPUESTA")]
        public RESPUESTA RESPUESTA { get; set; }
    }

    [XmlRoot(ElementName = "PORTALSERVICIOSMC")]
    public class PORTALSERVICIOSMC
    {

        [XmlElement(ElementName = "VALIDACREDENCIALES")]
        public VALIDACREDENCIALES VALIDACREDENCIALES { get; set; }
    }



}
