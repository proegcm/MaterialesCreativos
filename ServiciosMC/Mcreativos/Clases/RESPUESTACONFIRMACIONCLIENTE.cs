using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RespuestaConfirmacionCliente
{
    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTACONFIRMACIONCLIENTE
    {
        [XmlElement(ElementName = "CODCOB")]
        public string codcob { get; set; }
        [XmlElement(ElementName = "ESTADO")]
        public string estado { get; set; }
        [XmlElement(ElementName = "DESCRIPCION")]
        public string descripcion { get; set; }
    }
}
