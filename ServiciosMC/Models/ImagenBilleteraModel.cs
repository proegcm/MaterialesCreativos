using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiciosMC.Models
{
    public class ImagenBilleteraModel
    {
        public List<ImagenClienteBilletera> imagenes { get; set; }
        public class ImagenClienteBilletera
        {
            public string nombre { get; set; }
            public string baseImg { get; set; }
        }
    }
}
