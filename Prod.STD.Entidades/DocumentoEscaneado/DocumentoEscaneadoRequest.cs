using Prod.STD.Entidades._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.DocumentoEscaneado
{
    public class DocumentoEscaneadoRequest : BaseRequest
    {
        public int? id_documento { get; set; }
        public int? id_anexo { get; set; }
        public int? tipo_registro { get; set; }
        public string numero_tramite { get; set; }
        public string razon_social { get; set; }
        public string asunto { get; set; }
        public int? folios { get; set; }
        public int? coddep { get; set; }
        public string fecha_registro_v { get; set; }
        public string usuario { get; set; }
        public string estado_documento { get; set; }
        public string ruta { get; set; }
        public string pdf { get; set; }
        public DateTime? audit_rec { get; set; }
        public string documento_estado { get; set; }
        public int? numero_reporte { get; set; }
    }
}
