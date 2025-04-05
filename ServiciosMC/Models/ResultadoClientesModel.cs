using System;
using System.Collections.Generic;
namespace ServiciosMC.Models
{
    public class RespuestaClientes
    {
        public string CODIGO { get; set; }
        public string MENSAJE { get; set; }
        public List<Cliente> CLIENTES { get; set; }
    }

    public class ResultadoClientesModel
    {
        public bool existeError { get; set; }
        public bool existenDatos { get; set; }
        public InfoClientes infoClientes { get; set; }
    }

    public class InfoClientes
    {
        public List<Cliente> listaClientes { get; set; }
    }

    public class Cliente
    {
        public string nombre { get; set; }
    }
}
