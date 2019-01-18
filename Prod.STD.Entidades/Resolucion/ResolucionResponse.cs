using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Resolucion
{
    public class ResolucionResponse
    {
        public int id_resolucion { get; set; }
        public string tipo { get; set; }
        public string numero { get; set; }
        public string sumilla { get; set; }
        public string fecha_firma { get; set; }
        public string fecha_publicacion { get; set; }
    }
}
