using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class ReimpresionGuiaModel
    {
        public string noguia { get; set; }
        public string respuesta { get; set; }
        public string descripcion { get; set; }
        public string urlguia { get; set; }
    }
}
