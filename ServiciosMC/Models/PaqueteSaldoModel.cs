using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class PaqueteSaldoModel
    {
        public string codcob { get; set; }
        public string fecha { get; set; }
        public string monto { get; set; }
        public string banco { get; set; }

        public List<listaBoletas> listaBoletas { get; set; }

    }

    public class listaBoletas
    {
        public string nombreBoleta { get; set; }
        public string noBoleta { get; set; }
        public string ruta { get; set; }
        public string img { get; set; }
    }
}
