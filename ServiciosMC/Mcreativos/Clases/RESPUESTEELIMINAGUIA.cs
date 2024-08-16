using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RespuestaElimina
{

    [XmlRoot(ElementName = "EXITO")]
    public class EXITO
    {

        [XmlElement(ElementName = "CODIGO")]
        public string CODIGO { get; set; }

        [XmlElement(ElementName = "DESCRIPCION")]
        public string DESCRIPCION { get; set; }
    }

    [XmlRoot(ElementName = "ERROR")]
    public class ERROR
    {

        [XmlElement(ElementName = "CODIGO")]
        public string CODIGO { get; set; }

        [XmlElement(ElementName = "DESCRIPCION")]
        public string DESCRIPCION { get; set; }
    }


    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTA
    {
        [XmlElement(ElementName = "ERROR")]
        public ERROR ERROR { get; set; }

        [XmlElement(ElementName = "NUMERO_GUIA")]
        public string NUMEROGUIA { get; set; }

        [XmlElement(ElementName = "EXITO")]
        public EXITO EXITO { get; set; }
    }
}
