using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class ResultadoTarificadorModel
    {
        public string codigoRespuesta { get; set; }
        public string descripcionRespuesta { get; set; }
        public string codigoEnvio { get; set; }
        public string cantidadPiezas { get; set; }
        public string pesoEnvio { get; set; }
        public string tarifaEnvio { get; set; }

    }
}
