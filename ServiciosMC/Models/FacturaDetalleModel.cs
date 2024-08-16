using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class FacturaDetalleModel
    {

        public string id_factura { get; set; }
        public string id_detalle { get; set; }
        public string producto { get; set; }
        public string cantidad { get; set; }
        public string valor_unitario { get; set; }
        public string valor_total { get; set; }

     
    }
    
}
