using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Comun
{
    public class ClaseDocumentoResponse
    {
        public int? id_clase_documento_interno { get; set; }
        public string descripcion { get; set; }
        public string procedencia { get; set; }
        public string categoria { get; set; }
    }
}
