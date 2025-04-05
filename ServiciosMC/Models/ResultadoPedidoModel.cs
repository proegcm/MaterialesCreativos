using System;
using System.Collections.Generic;
namespace ServiciosMC.Models
{

    public class RespuestaPedido
    {
        public string CODIGO { get; set; }
        public string MENSAJE { get; set; }
        public InfoPedido PEDIDO { get; set; }
    }

    public class ResultadoPedidoModel
    {
        public bool existeError { get; set; }
        public bool existenDatos { get; set; }
        public InfoPedido infoPedido {get; set;}

    }

    public class InfoPedido
    {
        public int idTicket { get; set; }
        public int folio { get; set; }
        public string fecha { get; set; }
        public string cajero { get; set; }
        public string cliente { get; set; }
        public decimal total { get; set; }
        public decimal pago { get; set; }
        public decimal cambio { get; set; }
        public string estatus { get; set; }
        public List<ArticulosPedido> detallePedido { get; set; }
    }

    public class ArticulosPedido
    {
        public string producto { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
    }


    public class infoIngreso
    {
        public InfoPedido infoPedido { get; set; }
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
        public List<InfoPedido> listadoPedidos { get; set; }
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

    public class infoRolIngreso
    {
        public string nombrerol { get; set; }
    }

    public class infoPaqueteriaIngreso
    {
        public string nombre_paqueteria { get; set; }
    }

    public class infoUsuarioEditar
    {
        public string id { get; set; }

        public string nombre { get; set; }

        public string telefono { get; set; }

        public string activo { get; set; }

        public string username { get; set; }

        public string password { get; set; }

        public string idrol { get; set; }

        public string usrcambio { get; set; }
    }

    public class infoRolEditar
    {
        public string id_rol { get; set; }

        public string nombrerol { get; set; }
    }

    public class infoPaqueteriaEditar
    {
        public string id_paqueteria { get; set; }

        public string nombre { get; set; }
    }

    public class infoEliminaUsuario 
    {
        public string id_usuario { get; set; }

        public string username { get; set; }
    }


    public class infoHistorial
    {
        public string usuarioConsulta { get; set; }
        public string usuario { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string estado { get; set; }
    }
}
