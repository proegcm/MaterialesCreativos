using ServiciosMC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases
{
    public class RESPUESTAPAQUETESALDOWS
    {

        [XmlElement(ElementName = "CODCOB")]
        public string codcob { get; set; }

        [XmlElement(ElementName = "FECHA")]
        public string fecha { get; set; }

        [XmlElement(ElementName = "MONTO")]
        public string monto { get; set; }

        [XmlElement(ElementName = "BANCO")]
        public string banco { get; set; }

        [XmlArray("IMAGENES")]
        [XmlArrayItem("IMAGEN", typeof(listaBoletas))]
        public List<listaBoletas> listaBoletas { get; set; }

    }

    [XmlRoot(ElementName = "SOLICITUD")]
    public class listaBoletas
    {
        [XmlElement(ElementName = "NOMBREBOLETA")]
        public string nombreBoleta { get; set; }

        [XmlElement(ElementName = "NOBOLETA")]
        public string NoBoleta { get; set; }

        [XmlElement(ElementName = "RUTA")]
        public string ruta { get; set; }

        [XmlElement(ElementName = "IMG")]
        public string img { get; set; }
    }
}
