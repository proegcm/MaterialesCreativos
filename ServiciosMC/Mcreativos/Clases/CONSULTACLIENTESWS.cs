using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases
{



    [XmlRoot(ElementName = "INFORMACIONCLIENTE")]
    public class INFORMACIONCLIENTE
    {

        [XmlElement(ElementName = "CODIGOCLIENTE")]
        public string CODIGOCLIENTE { get; set; }

        [XmlElement(ElementName = "NOMBRE")]
        public string NOMBRE { get; set; }

        [XmlElement(ElementName = "DIRECCION")]
        public string DIRECCION { get; set; }

        [XmlElement(ElementName = "TELEFONO")]
        public string TELEFONO { get; set; }

        [XmlElement(ElementName = "ESCOD")]
        public string ESCOD { get; set; }
    }

    [XmlRoot(ElementName = "TIPOENVIO")]
    public class TIPOENVIO
    {

        [XmlElement(ElementName = "CODIGOENVIO")]
        public int CODIGOENVIO { get; set; }

        [XmlElement(ElementName = "NOMBREENVIO")]
        public string NOMBREENVIO { get; set; }
    }

    [XmlRoot(ElementName = "TIPOSENVIOS")]
    public class TIPOSENVIOS
    {

        [XmlElement(ElementName = "TIPOENVIO")]
        public List<TIPOENVIO> TIPOENVIO { get; set; }
    }

    [XmlRoot(ElementName = "CONSULTACLIENTESWS")]
    public class CONSULTACLIENTESWS
    {

        [XmlElement(ElementName = "VALIDACREDENCIALES")]
        public VALIDACREDENCIALES VALIDACREDENCIALES { get; set; }

        [XmlElement(ElementName = "INFORMACIONCLIENTE")]
        public INFORMACIONCLIENTE INFORMACIONCLIENTE { get; set; }

        [XmlElement(ElementName = "TIPOSENVIOS")]
        public TIPOSENVIOS TIPOSENVIOS { get; set; }
    }

}
