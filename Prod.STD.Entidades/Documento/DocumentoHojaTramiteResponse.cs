using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Documento
{
    public class DocumentoHojaTramiteResponse
    {
        public string num_tram_documentario { get; set; }
        public string tipo { get; set; }
        public string fecha { get; set; }
        public string razon_social { get; set; }
        public string asunto { get; set; }
        public string nro_documento { get; set; }
        public int? folios { get; set; }
        public string observaciones { get; set; }
        public string dependencia { get; set; }
        public string documento { get; set; }

        public string fecha_max_plazo { get; set; }
        public int? dias_tramite { get; set; }
        public string estado { get; set; }
        public DateTime? fecha_finalizacion { get; set; }
        public string oficina_finalizacion { get; set; }
        public string oficinas_pendientes { get; set; }
        public int? dias_catalogados_tupa { get; set; }
        public int? dias_suspension_tupa { get; set; }
    }
}
