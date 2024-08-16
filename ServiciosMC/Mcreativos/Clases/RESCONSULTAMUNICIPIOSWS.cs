using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases
{

    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(RESCONSULTAMUNICIPIOSWS));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (RESCONSULTAMUNICIPIOSWS)serializer.Deserialize(reader);
    // }


    [XmlRoot(ElementName = "MUNICIPIO")]
    public class MUNICIPIO
    {

        [XmlElement(ElementName = "CODIGO")]
        public string CODIGO { get; set; }

        [XmlElement(ElementName = "NOMBRE")]
        public string NOMBRE { get; set; }
    }

    [XmlRoot(ElementName = "MUNICIPIOS")]
    public class MUNICIPIOS
    {

        [XmlElement(ElementName = "MUNICIPIO")]
        public List<MUNICIPIO> MUNICIPIO { get; set; }
    }

    [XmlRoot(ElementName = "RESCONSULTAMUNICIPIOSWS")]
    public class RESCONSULTAMUNICIPIOSWS
    {

        [XmlElement(ElementName = "VALIDACREDENCIALES")]
        public VALIDACREDENCIALES VALIDACREDENCIALES { get; set; }

        [XmlElement(ElementName = "MUNICIPIOS")]
        public MUNICIPIOS MUNICIPIOS { get; set; }
    }




}
