using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class EnvioImagenesModel
    {
        public string codigo { get; set; }
        public List<imagen> imagenes { get; set; }
    }

    public class imagen
    {
        public string nombre { get; set; }
        public string baseImg { get; set; }
    }
}