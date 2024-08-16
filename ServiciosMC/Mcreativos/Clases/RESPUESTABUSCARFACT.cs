using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiciosMC.Mcreativos.Clases.RBUSCARF
{



    [XmlRoot(ElementName = "RESPUESTA")]
    public class RESPUESTABUSCARFACT
    {
        [XmlElement(ElementName = "DATOSFACTURA")]
        public DATOSFACTURA datosFacturaBuscar { get; set; }

        [XmlArray("DETALLEFACTURA")]
        [XmlArrayItem("DETALLE", typeof(DETALLE))]
        public List<DETALLE> detalles { get; set; }
    }


    
    public class DATOSFACTURA
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

 
    public class DETALLE
    {
        [XmlElement(ElementName = "IDDETALLE")]
        public string id_detalle { get; set; }

        [XmlElement(ElementName = "IDF")]
        public string id_factura { get; set; }
       
        [XmlElement(ElementName = "PRODUCTO")]
        public string producto { get; set; }
        [XmlElement(ElementName = "CANTIDAD")]
        public string cantidad { get; set; }


        [XmlElement(ElementName = "UNITARIO")]
        public string valor_unitario { get; set; }


        [XmlElement(ElementName = "TOTAL")]
        public string valor_total { get; set; }
    }


   
    //public class DETALLEFACTURA
    //{
    //    [XmlElement(ElementName = "DETALLE")]
    //    public List<DETALLE> detalles { get; set; }
    //}





}



