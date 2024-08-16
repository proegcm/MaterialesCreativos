using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases
{


    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(RESCONSULTADEPARTAMENTOSWS));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (RESCONSULTADEPARTAMENTOSWS)serializer.Deserialize(reader);
    // }


    [XmlRoot(ElementName = "DEPARTAMENTO")]
    public class DEPARTAMENTO
    {

        [XmlElement(ElementName = "CODIGO")]
        public string CODIGO { get; set; }

        [XmlElement(ElementName = "NOMBRE")]
        public string NOMBRE { get; set; }
    }

    [XmlRoot(ElementName = "DEPARTAMENTOS")]
    public class DEPARTAMENTOS
    {

        [XmlElement(ElementName = "DEPARTAMENTO")]
        public List<DEPARTAMENTO> DEPARTAMENTO { get; set; }
    }

    [XmlRoot(ElementName = "RESCONSULTADEPARTAMENTOSWS")]
    public class RESCONSULTADEPARTAMENTOSWS
    {

        [XmlElement(ElementName = "VALIDACREDENCIALES")]
        public VALIDACREDENCIALES VALIDACREDENCIALES { get; set; }

        [XmlElement(ElementName = "DEPARTAMENTOS")]
        public DEPARTAMENTOS DEPARTAMENTOS { get; set; }
    }



}
