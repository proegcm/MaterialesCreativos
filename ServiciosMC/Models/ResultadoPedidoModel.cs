using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class ResultadoPedidoModel
    {
        public bool existeError { get; set; }
        public bool existenDatos { get; set; }
        public infoPedido infoPedido {get; set;}

    }

    public class infoPedido
    {
        public string folio { get; set; }

        public string fecha { get; set; }

        public string cajero { get; set; }

        public string cliente { get; set; }

        public string total { get; set; }

        public string pago { get; set; }

        public string cambio { get; set; }

        public string estatus { get; set; }
    }

    public class infoIngreso
    {
        public infoPedido infoPedido { get; set; }
        public string usuario { get; set; }
    }

    public class infoUsuario
    {
        public string usuario { get; set; }
    }

   public class infoConsultaPedidos
    {
        public infoUsuario infoUsuario { get; set; }
    }

    public class arrayPedidos
    {
        public List<infoPedido> listadoPedidos { get; set; }
    }


}
