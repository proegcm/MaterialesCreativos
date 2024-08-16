using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class TrackingGuiaModel
    {
        public string noguia { get; set; }
        public string llave { get; set; }
        public string codigo { get; set; }
        public string respuesta { get; set; }
        public InformacionTracking informacionTracking { get; set; }
        public List<tracking> tracking { get; set; }

    }

    public class InformacionTracking
    {
        public string frecuenciaVisitaRemitente { get; set; }
        public string frecuenciaVisitaDestinatario { get; set; }
        public string fechaCreacion { get; set; }
        public string direccionRemitente1 { get; set; }
        public string direccionRemitente2 { get; set; }
        public string nombreDestinatario { get; set; }
        public string direccionDestinatario1 { get; set; }
        public string direccionDestinatario2 { get; set; }
        public string PTOORI { get; set; }
        public string PTODES { get; set; }
        public string CODCOB { get; set; }
        public string telefonoDestinatario { get; set; }
        public string tarifa { get; set; }
        public string piezas { get; set; }
        public string Lcredito { get; set; }
        public string LXCobrar { get; set; }
        public string LPrepagada { get; set; }
        public string LContadoFrecuente { get; set; }
        public string telefonoRemitente { get; set; }
        public string ho { get; set; }
        public string ra { get; set; }
        public string recibio { get; set; }
        public string cedula { get; set; }
        public string fecha { get; set; }
        public string hora { get; set; }
        public string serieFactura { get; set; }
        public string Factura { get; set; }
        public string recogeOficina { get; set; }
        public string COBEX { get; set; }
        public string CodigoDestinatario { get; set; }
        public string CodigoRemitente { get; set; }
        public string valorCobrarCOD { get; set; }

        public string codLiquidado { get; set; }
        
        public string codLiquidadoFecha { get; set; }
        public string estadoIMN { get; set; }
        public string fechaEntregaIMN { get; set; }
        public string estado { get; set; }
        public string llaveCliente { get; set; }
        public string noguia { get; set; }
        public string MNCPORI { get; set; }
        public string MNCPDES { get; set; }
        public string nombreRemitente { get; set; }

        public string movimiento { get; set; }
    }

    public class tracking
    {
        public string fecha { get; set; }
        public string hora { get; set; }
        public string estado { get; set; }
        public string ruta { get; set; }
        public string movimiento { get; set; }
        public string noguia { get; set; }
        public string descripcion { get; set; }
        public string pos { get; set; }
    }
}
