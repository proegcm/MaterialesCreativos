using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RESCONSULTANOCOBERTURA
{

    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTA
    {
        [XmlElement(ElementName = "CODIGO")]
        public String CODIGO { get; set; }

        [XmlElement(ElementName = "DESCRIPCION")]
        public string DESCRIPCION { get; set; }
    }

    [XmlRoot(ElementName = "NOCOBERTURA")]
    public class NOCOBERTURA
    {
        [XmlElement(ElementName = "CODIGO")]
        public String CODIGO { get; set; }

        [XmlElement(ElementName = "DEPARTAMENTO")]
        public String DEPARTAMENTO { get; set; }

        [XmlElement(ElementName = "MUNICIPIO")]
        public String MUNICIPIO { get; set; }

        [XmlElement(ElementName = "ZONA")]
        public String ZONA { get; set; }

        [XmlElement(ElementName = "COLONIA")]
        public String COLONIA { get; set; }

        [XmlElement(ElementName = "OBSERVACIONES")]
        public String OBSERVACIONES { get; set; }


    }

    [XmlRoot(ElementName = "VALIDACREDENCIALES")]
    public class VALIDACREDENCIALES
    {
        [XmlElement(ElementName = "RESPUESTA")]
        public RESPUESTA RESPUESTA { get; set; }
    }

    [XmlRoot(ElementName = "NOCOBERTURAS")]
    public class NOCOBERTURAS
    {
        [XmlElement(ElementName = "NOCOBERTURA")]
        public List<NOCOBERTURA> NOCOBERTURA { get; set; }
    }

    [XmlRoot(ElementName = "RESPGCONSULTAWS")]
    public class RESPGCONSULTAWS
    {
        [XmlElement(ElementName = "VALIDACREDENCIALES")]
        public VALIDACREDENCIALES VALIDACREDENCIALES { get; set; }

        [XmlElement(ElementName = "NOCOBERTURAS")]
        public NOCOBERTURAS NOCOBERTURAS { get; set; }
    }

}
