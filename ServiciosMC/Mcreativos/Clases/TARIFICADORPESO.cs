using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RespuestaTarifica
{
    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTA
    {
        [XmlElement(ElementName ="CODIGO")]
        public String CODIGO { get; set; }

        [XmlElement(ElementName = "DESCRIPCION")]
        public string DESCRIPCION { get; set; }
    }

    [XmlRoot(ElementName ="INFORMACIONENVIO")]
    public class INFORMACIONENVIO
    {
        [XmlElement(ElementName ="CODIGOENVIO")]
        public string CODIGOENVIO { get; set; }

        [XmlElement(ElementName ="CANTPIEZAS")]
        public string CANTPIEZAS { get; set; }

        [XmlElement(ElementName = "PESOENVIO")]
        public string PESOENVIO { get; set; }

        [XmlElement(ElementName = "TARIFAENVIO")]
        public string TARIFAENVIO { get; set; }
     }


    [XmlRoot(ElementName = "VALIDACREDENCIALES")]
    public class VALIDACREDENCIALES
    {
        [XmlElement(ElementName = "RESPUESTA")]
        public RESPUESTA RESPUESTA { get; set; }
    }

    [XmlRoot(ElementName ="TARIFICADORWS")]
    public class TARIFICADORWS
    {
        [XmlElement(ElementName = "VALIDACREDENCIALES")]
        public VALIDACREDENCIALES VALIDACREDENCIALES { get; set; }

        [XmlElement(ElementName = "INFORMACIONENVIO")]
        public INFORMACIONENVIO INFORMACIONENVIO { get; set; }
    }

}
