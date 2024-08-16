using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace ServiciosMC.Mcreativos.Clases.RFACTURA
{
    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTAFACT
    {
        [XmlElement(ElementName = "IDFACTURA")]
        public string idFactura { get; set; }
        
        
        [XmlElement(ElementName = "SERIE")]
        public string serie { get; set; }
        
        
        [XmlElement(ElementName = "CORRELATIVO")]
        public string correlativo { get; set; }
        
        
        [XmlElement(ElementName = "NOMBRE")]
        public string nombre { get; set; }


        [XmlElement(ElementName = "NIT")]
        public string nit { get; set; }


        [XmlElement(ElementName = "FECHA")]
        public string fecha { get; set; }
        

        [XmlElement(ElementName = "TOTALFACTURADO")]
        public string totalFacturado { get; set; }

        
        [XmlElement(ElementName = "TOTALSINIVA")]
        public string totalsinIVA { get; set; }

        
        [XmlElement(ElementName = "MENSAJE")]
        public string mensaje { get; set; }


    }


}
