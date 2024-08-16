using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.OBTENGOSALDO
{
    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTACODIGOPREPAGO
    {
        [XmlElement(ElementName = "SALDO")]

        public string saldo { get; set; }
    }
}
