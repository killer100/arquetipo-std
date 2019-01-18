using Release.Helper.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Anexo
{
    public class AnexoFilter : PagedRequest
    {
        public string num_documento_anexo { get; set; }
        public int? coddep_oficina_derivada { get; set; }
        public DateTime? fecha_inicio { get; set; }
        public DateTime? fecha_fin { get; set; }
    }
}
