using Release.Helper.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.DocumentoEscaneado
{
    public class DocumentoEscaneadoFilter: PagedRequest
    {
        public int? estado { get; set; }

        public DateTime? fecha_inicio { get; set; }

        public DateTime? fecha_fin { get; set; }

        public int? coddep { get; set; }

    }
}
