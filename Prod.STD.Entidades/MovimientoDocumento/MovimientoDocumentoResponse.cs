using Prod.STD.Entidades.Comun;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.MovimientoDocumento
{
    public class MovimientoDocumentoResponse
    {
        public int id_movimiento_documento { get; set; }
        public int id_documento { get; set; }
        public int? id_ruta_tupa { get; set; }
        public int id_dependencia_origen { get; set; }
        public int id_dependencia_destino { get; set; }
        public int? id_oficio { get; set; }
        public int? folios { get; set; }
        public string observaciones { get; set; }
        public string fecha_respuesta { get; set; }
        public DateTime? audit_mod { get; set; }
        public DateTime? audit_rec { get; set; }
        public string estado { get; set; }
        public string avance { get; set; }
        public int enviado { get; set; }
        public int derivado { get; set; }
        public int finalizado { get; set; }
        public string fecha_plazo { get; set; }
        public int? codigo_trabajador { get; set; }
        public string fecha_plazo_interno { get; set; }
        public DateTime? audit_trab_der { get; set; }
        public DateTime? audit_trab_rec { get; set; }
        public string tratamiento { get; set; }
        public int? condicion { get; set; }
        public string ultimo_avance { get; set; }
        public virtual DependenciaResponse dependencia_origen { get; set; }
        public virtual DependenciaResponse dependencia_destino { get; set; }
    }
}
