using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class TarificadorModel
    {
        public String CODCOB { get; set; }
        public String CodigoEnvio { get; set; }
        public String CantidadPiezas { get; set; }
        public String PesoEnvio { get; set; }
        public String CodigoOrigen { get; set; }
        public String CodigoDestino { get; set; }
    }
}
