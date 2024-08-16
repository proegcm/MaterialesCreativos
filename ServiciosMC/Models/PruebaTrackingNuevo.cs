using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class PruebaTrackingNuevo
    {
        public String noenviotr { get; set; }
        public List<TrackingNuevo> ntracking { get; set; }
    }
    public class TrackingNuevo
    {
        public String movimiento { get; set; }
        public String bodega { get; set; }
        public String estado { get; set; }
    }
}


