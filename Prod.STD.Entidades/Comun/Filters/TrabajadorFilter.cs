using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Comun.Filters
{
    public class TrabajadorFilter
    {
        public List<int> codigos_dependencia { get; set; }

        public string estado { get; set; } = "ACTIVO";

        public int? director { get; set; }

        public string nombre { get; set; }
    }
}
