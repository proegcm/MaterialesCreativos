using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RespuestaGuia
{

    [XmlRoot(ElementName = "GUIA")]
    public class GUIA
    {

        [XmlElement(ElementName = "ID_GUIA")]
        public int IDGUIA { get; set; }

        [XmlElement(ElementName = "NOGUIA")]
        public string NOGUIA { get; set; }
    }


    [XmlRoot(ElementName = "CORRELATIVOGUIA1")]
    public class CORRELATIVOGUIA1
    {

        [XmlElement(ElementName = "CODIGO")]
        public int CODIGO { get; set; }

        [XmlElement(ElementName = "DESCRIPCION")]
        public string DESCRIPCION { get; set; }
    }

    [XmlRoot(ElementName = "GUIAS")]
    public class GUIAS
    {
        [XmlElement(ElementName = "GUIA")]
        public GUIA GUIA { get; set; }

        [XmlElement(ElementName = "CORRELATIVOGUIA1")]
        public List<CORRELATIVOGUIA1> CORRELATIVOGUIA1 { get; set; }
    }

    [XmlRoot(ElementName = "SERVICIO")]
    public class SERVICIO
    {
        [XmlElement(ElementName = "URLGUIAS")]
        public string URLGUIAS { get; set; }

        [XmlElement(ElementName = "CODIGO")]
        public string CODIGO { get; set; }

        [XmlElement(ElementName = "GUIAS")]
        public GUIAS GUIAS { get; set; }
    }

    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTA
    {

        [XmlElement(ElementName = "SERVICIO")]
        public SERVICIO SERVICIO { get; set; }
    }
}
