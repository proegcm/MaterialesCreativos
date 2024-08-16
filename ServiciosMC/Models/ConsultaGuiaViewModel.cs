using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class ConsultaGuiaViewModel
    {
        public string noguia { get; set; }
        public string recolectada { get; set; }
        public string fecha_creacion { get; set; }
        public string nombre_remitente { get; set; }
        public string direccion_remitente { get; set; }
        public string nombre_destinatario { get; set; }
        public string direccion_destinatario { get; set; }
        public string punto_origen { get; set; }
        public string punto_destino { get; set; }
        public string codigo_cobro { get; set; }
        public string telefono_destinatario { get; set; }
        public string municipio_origen { get; set; }
        public string municipio_destino { get; set; }
        public string telefono_remitente { get; set; }
        public string ho { get; set; }
        public string ra { get; set; }
        public string recibio { get; set; }
        public string cedula { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string cobertura_extra { get; set; }
        public string codigo_destinatario { get; set; }
        public string codigo_remitente { get; set; }
        public string cod_valor_a_cobrar { get; set; }
        public string factura { get; set; }

        public String autorizacionch  { get; set; }

        public String facredita { get; set; }
        public String tarifaenvio { get; set; }

        public String peso { get; set; }

        public String liquidado { get; set; }

    }
}
