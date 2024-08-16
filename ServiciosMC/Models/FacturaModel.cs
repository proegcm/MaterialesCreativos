using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class FacturaModel
    {
        public string idFactura { get; set; }
        public string serie { get; set; }
        public string correlativo { get; set; }
        public string nombre { get; set; }
        public string nit { get; set; }
        public string fecha { get; set; }
        public string totalFacturado { get; set; }
        public string totalsinIVA { get; set; }
        public string mensaje { get; set; }

    }




}
