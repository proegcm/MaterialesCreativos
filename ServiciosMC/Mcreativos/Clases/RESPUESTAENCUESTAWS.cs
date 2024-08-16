using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RESPUESTACONSULTAENCUESTA
{


    [XmlRoot(ElementName = "LISTADO")]
    public class RESPUESTAENCUESTAWS
    {
        [XmlArray("SERVICIOS")]
        [XmlArrayItem("SERVICIO", typeof(String))]
        public List<String> SERVICIOS { get; set; }

    }



}
