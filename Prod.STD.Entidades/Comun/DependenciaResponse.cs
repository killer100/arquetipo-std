using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Comun
{
    public class DependenciaResponse
    {
        public int? codigo_dependencia { get; set; }
        public string dependencia { get; set; }
        public string siglas { get; set; }
        public string condicion { get; set; }
        public int? id_tipo_dependencia { get; set; }
        public string seccion { get; set; }
    }
}
