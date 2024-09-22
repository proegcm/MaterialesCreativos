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



    public class infoCambioPedido
    {
        public string folio { get; set; }
        public string estadoAnterior { get; set; }
        public string estadoNuevo { get; set; }
        public string usuario { get; set; }
        public string idMensajero { get; set; }
        public string idPaqueteria { get; set; }
        public string observaciones { get; set; }


    }

    public class infoUsuarioIngreso
    {
        public string nombre { get; set; }

        public string telefono { get; set; }

        public string activo { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string idrol { get; set; }
    }
}
