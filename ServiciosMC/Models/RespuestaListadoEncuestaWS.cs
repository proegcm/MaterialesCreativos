using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class RespuestaListadoEncuestaWS
    {
        public List<OpcionSERVICIO> servicios { get; set; }
    }

    public class OpcionSERVICIO
    {
        public string s { get; set; }
    }
}
