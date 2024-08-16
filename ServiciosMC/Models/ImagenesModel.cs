using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class ImagenesModel
    { 
        public string tipo { get; set; }

        public string dpi { get; set; }

        public string codigomensaje { get; set; }

        public string mensaje { get; set; }

        public List<Imagen> imagenes { get; set; }
    }


    public class Imagen
    {
        public string ubicacion { get; set; }
        public string img { get; set; }
    }
}
