using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.DocumentoReferencia
{
    public class DocumentoReferenciaRequest
    {
        public string numero_hoja_tramite { get; set; }
        public string tipo_hoja_tramite { get; set; }
        public int id_hoja_tramite { get; set; }
        public int id_documento_referencia { get; set; }
    }
}
