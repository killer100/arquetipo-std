using Prod.STD.Entidades._Base;
using Prod.STD.Entidades.DocumentoEscaneado;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.DocumentoEscaneado
{
    public class ReporteDocumentosEscaneadosRequest : BaseRequest
    {
        public IList<DocumentoEscaneadoRequest> documentos { get; set; }

        public string observaciones { get; set; }

        public int? codigo_dependencia_entrega { get; set; }

        public int? codigo_trabajador_entrega { get; set; }

        public int? codigo_dependencia_recibido { get; set; }

        public int? codigo_trabajador_recibido { get; set; }

        public int correlativo { get; set; }

        public int id_reporte { get; set; }
    }
}
