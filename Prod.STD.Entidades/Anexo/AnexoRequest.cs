using Prod.STD.Entidades._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Anexo
{
    public class AnexoRequest
    {
        public int? id_anexo { get; set; }
        public int? id_documento { get; set; }
        public int? id_tipo_anexo { get; set; }
        public string num_documento_anexo { get; set; }
        public int? id_persona_destino { get; set; }
        public int? folios { get; set; }
        public string contenido { get; set; }
        public string observaciones { get; set; }
        public string usuario { get; set; }
        public DateTime? audit_mod { get; set; }
        public int? coddep { get; set; }
        public string modificado { get; set; }
        public int? id_persona { get; set; }
        public int? correlativo { get; set; }
        public int? id_documento_adjunto { get; set; }
        public int estado_adjunto { get; set; }
        public string motivo_anulacion { get; set; }

        //public virtual tipo_anexo tipo_anexo { get; set; }
    }
}
