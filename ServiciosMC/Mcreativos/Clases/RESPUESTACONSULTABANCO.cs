using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RESPUESTACONSULTABANCO
{


    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTA
    {
        [XmlElement(ElementName = "CODIGO")]
        public String CODIGO { get; set; }

        [XmlElement(ElementName = "DESCRIPCION")]
        public String DESCRIPCION { get; set; }
    }

    [XmlRoot(ElementName = "BANCO")]
    public class BANCO
    {
        [XmlElement(ElementName = "CODIGO")]
        public String CODIGO { get; set; }
            
        [XmlElement(ElementName = "NOMBRE")]
        public String NOMBRE { get; set; }

        [XmlElement(ElementName = "CODTRAN")]
        public String CODTRAN { get; set; }
    }

    [XmlRoot(ElementName = "VALIDACREDENCIALES")]
    public class VALIDACREDENCIALES
    {
        [XmlElement(ElementName = "RESPUESTA")]
        public RESPUESTA RESPUESTA { get; set; }
    }

    [XmlRoot(ElementName = "LISTABANCO")]
    public class LISTABANCO
    {
        [XmlElement(ElementName = "BANCO")]
        public List<BANCO> BANCO { get; set; }
    }

    [XmlRoot(ElementName = "RESPGCONSULTAWS")]
    public class RESPGCONSULTAWS
    {
        [XmlElement(ElementName = "VALIDACREDENCIALES")]
        public VALIDACREDENCIALES VALIDACREDENCIALES { get; set; }

        [XmlElement(ElementName = "LISTABANCO")]
        public LISTABANCO LISTABANCO { get; set; }
    }

}
