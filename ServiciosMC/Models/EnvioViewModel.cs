using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class EnvioViewModel
    {

        public Remitente Remitente { get; set; }

        public Destinatario Destinatario { get; set; }

        public Servicio Servicio { get; set; }

        public List<Pieza> Piezas { get; set; }
    }


    public class Remitente
    {
        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string Departamento { get; set; }

        public string Municipio { get; set; }

        public string Cobertura { get; set; }

        public string Contacto { get; set; }

        public string LlaveBusqueda { get; set; }

    }


    public class Destinatario
    {

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public string Departamento { get; set; }

        public string Municipio { get; set; }

        public string Cobertura { get; set; }

    }


    public class Servicio
    {

        public string CodigoCobro { get; set; }

        public string TipoServicio { get; set; }

        public decimal ValorCOD { get; set; }

        public string Abrir { get; set; }

        public string ObservacionesServicio { get; set; }

        public string ObservacionesEntrega { get; set; }

        public string DescripcionEnvio { get; set; }

        public string Declarado { get; set; }

        public string Seguro { get; set; }

        public Boolean Pago_contado_seguro { get; set; }

        public String tipoformapago { get; set; }
    }

    public class Pieza
    {
        public int TipoPieza { get; set; }

        public int Cantidad { get; set; }


        public decimal Peso { get; set; }

    }


}
