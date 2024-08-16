using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class ResultadoBancoModel
    {
        public List<Banco> Bancos { get; set; }
    }

    public class Banco
    {
        public string codigo { get; set; }

        public string nombre { get; set; }

        public string codtran { get; set; }
    }
}
