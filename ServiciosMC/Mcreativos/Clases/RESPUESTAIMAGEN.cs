using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RespuestaImagen
{
    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTAIMAGEN
    {
        [XmlElement(ElementName = "TIPO")]
        public string tipo { get; set; }

        [XmlElement(ElementName = "DPI")]
        public string dpi { get; set; }

        [XmlElement(ElementName = "CODIGOMENSAJE")]
        public string codigomensaje { get; set; }

        [XmlElement(ElementName = "MENSAJE")]
        public string mensaje { get; set; }

        [XmlArray("IMAGENES")]
        [XmlArrayItem("IMAGEN", typeof(Imagen))]
        public List<Imagen> imagenes { get; set; }
    }

    [XmlRoot(ElementName = "RESPUESTATRACKINGGUIAS")]
    public class Imagen
    {
        [XmlElement(ElementName = "UBICACION")]
        public string ubicacion { get; set; }

        [XmlElement(ElementName = "BASE_IMG")]
        public string img { get; set; }
    }
}
