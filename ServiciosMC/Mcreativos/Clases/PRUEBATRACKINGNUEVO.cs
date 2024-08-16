using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.PruebaTrackingNuevo
{
    [XmlRoot(ElementName = "CONSULTA")]
    public class PRUEBATRACKINGNUEVO
    {

        [XmlElement(ElementName = "NOENVIO")]
        public string NOENVIOTR { get; set; }

        [XmlElement(ElementName = "TRACKING")]
        public NUEVOTRACKING NTRACKING { get; set; }
    }

    [XmlRoot(ElementName = "TRACKING")]
    public class NUEVOTRACKING
    {
        [XmlElement(ElementName = "DETALLE")]
        public List<NMOVIMIENTO> NMOVIMIENTO { get; set; }
    }

    [XmlRoot(ElementName = "DETALLE")]
    public class NMOVIMIENTO
    {
        [XmlElement(ElementName = "MOVIMIENTO")]
        public string MOVIMIENTO { get; set; }

        [XmlElement(ElementName = "BODEGA")]
        public string BODEGA { get; set; }

        [XmlElement(ElementName = "ESTADO")]
        public string ESTADO { get; set; }
    }
}
