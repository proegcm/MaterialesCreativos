using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{ 
    public class RDatosFacModel
    {

        public FacturaModel factura { get; set; }

        public List<FacturaDetalleModel> listaD { get; set; }


        public RDatosFacModel()
        {
            factura = new FacturaModel();
            listaD = new List<FacturaDetalleModel>();
        }
    }
}
