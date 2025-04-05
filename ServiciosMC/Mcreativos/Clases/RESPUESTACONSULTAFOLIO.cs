using System.Xml.Serialization;
using System;
using System.Collections.Generic;

namespace ServiciosMC.Mcreativos.Clases
{
    public class RESPUESTACONSULTAFOLIO
    {
        [XmlRoot(ElementName = "RESPUESTA")]
        public class RESPUESTA
        {
            [XmlElement(ElementName = "CODIGO")]
            public string Codigo { get; set; }

            [XmlElement(ElementName = "MENSAJE")]
            public string Mensaje { get; set; }

            [XmlElement("PEDIDO", typeof(PEDIDO))]
            public PEDIDO Pedido { get; set; }
        }

        public class PEDIDO
        {
            [XmlElement(ElementName = "FOLIO")]
            public string Folio { get; set; }

            [XmlElement(ElementName = "FECHA")]
            public string Fecha { get; set; }

            [XmlElement(ElementName = "CAJERO")]
            public string Cajero { get; set; }

            [XmlElement(ElementName = "CLIENTE")]
            public string Cliente { get; set; }

            [XmlElement(ElementName = "TOTAL")]
            public string Total { get; set; }

            [XmlElement(ElementName = "PAGO")]
            public string Pago { get; set; }

            [XmlElement(ElementName = "CAMBIO")]
            public string Cambio { get; set; }

            [XmlElement(ElementName = "ESTATUS")]
            public string Estatus { get; set; }

            [XmlArray("DETALLE_PEDIDO")]
            [XmlArrayItem("ITEM")]
            public List<ITEM> DetallePedido { get; set; }
        }

        public class ITEM
        {
            [XmlElement(ElementName = "NOMBRE")]
            public string Nombre { get; set; }

            [XmlElement(ElementName = "CANTIDAD")]
            public int Cantidad { get; set; }

            [XmlElement(ElementName = "PRECIO")]
            public decimal Precio { get; set; }
        }
    }
}
