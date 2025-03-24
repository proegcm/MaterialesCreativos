using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class LoginViewModel
    {
        public string Usuario { get; set; }

        public string Password { get; set; }
    }

    public class AutorizacionResponse
    {
        public bool AUTORIZACION { get; set; }
        public string CODIGO { get; set; }
        public string ID { get; set; }
        public string MENSAJE { get; set; }
        public string TIPO { get; set; }

        public string NOMBRE { get; set; }
    }

}
