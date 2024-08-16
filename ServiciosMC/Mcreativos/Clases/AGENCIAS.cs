using System.Collections.Generic;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.AGENCIAS
{
    [XmlRoot(ElementName = "RESPUESTA")]
    public class AGENCIAS
    {
        [XmlArray("AGENCIAS")]
        [XmlArrayItem("AGENCIA", typeof(AGENCIA))]
        public List<AGENCIA> AGENCIASWEB{ get; set; }
    }


    public class AGENCIA
    {
        [XmlElement(ElementName = "CODIGO")]
        public string codigo { get; set; }
        [XmlElement(ElementName = "NOMBRE")]
        public string nombre { get; set; }
        [XmlElement(ElementName = "DIRECCION")]
        public string direccion { get; set; }
        [XmlElement(ElementName = "TELEFONO")]
        public string telefono { get; set; }
        [XmlElement(ElementName = "EMAIL")]
        public string email { get; set; }
        [XmlElement(ElementName = "HORARIO")]
        public string horario { get; set; }
    }
}
