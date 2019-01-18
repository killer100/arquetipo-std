using Prod.STD.Entidades.Enumerable;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Comun
{
    public class TipoResolucionResponse: EnumerableResponse
    {
        public int? id { get; set; }
        public string descripcion { get; set; }
        public string descrip_completa { get; set; }
    }
}
