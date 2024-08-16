using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases
{

    // using System.Xml.Serialization;
    // XmlSerializer serializer = new XmlSerializer(typeof(RESPUNTOSCOBERTURAWS));
    // using (StringReader reader = new StringReader(xml))
    // {
    //    var test = (RESPUNTOSCOBERTURAWS)serializer.Deserialize(reader);
    // }



    [XmlRoot(ElementName = "PUNTOCOBERTURA")]
    public class PUNTOCOBERTURA
    {

        [XmlElement(ElementName = "CODIGO")]
        public string CODIGO { get; set; }

        [XmlElement(ElementName = "NOMBRE")]
        public string NOMBRE { get; set; }

        [XmlElement(ElementName = "PCOBERTURA")]
        public string PCOBERTURA { get; set; }

        [XmlElement(ElementName = "CODIGOAGENTE")]
        public string CODIGOAGENTE { get; set; }
    }

    [XmlRoot(ElementName = "PUNTOSCOBERTURA")]
    public class PUNTOSCOBERTURA
    {

        [XmlElement(ElementName = "PUNTOCOBERTURA")]
        public List<PUNTOCOBERTURA> PUNTOCOBERTURA { get; set; }
    }

    [XmlRoot(ElementName = "RESPUNTOSCOBERTURAWS")]
    public class RESPUNTOSCOBERTURAWS
    {

        [XmlElement(ElementName = "VALIDACREDENCIALES")]
        public VALIDACREDENCIALES VALIDACREDENCIALES { get; set; }

        [XmlElement(ElementName = "PUNTOSCOBERTURA")]
        public PUNTOSCOBERTURA PUNTOSCOBERTURA { get; set; }
    }




}
