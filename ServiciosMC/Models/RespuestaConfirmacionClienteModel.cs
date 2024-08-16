using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class RespuestaConfirmacionClienteModel
    {
        public string codcob { get; set; }
        public string estado { get; set; }
        public string descripcion { get; set; }
    }
}
