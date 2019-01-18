using Prod.STD.Entidades.Anexo;
using Prod.STD.Entidades.Comun;
using Prod.STD.Entidades.ContadorInterno;
using Prod.STD.Entidades.DocumentoCont;
using Prod.STD.Entidades.DocumentoCopia;
using Prod.STD.Entidades.EstadoDocumento;
using Prod.STD.Entidades.MovimientoDocumento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Documento
{
    public class DocumentoResponse
    {
        public int id_documento { get; set; }
        public int? id_persona { get; set; }
        public int? id_tup { get; set; }
        public int id_tipo_documento { get; set; }
        public int id_estado_documento { get; set; }
        public int? id_clase_documento_interno { get; set; }
        public string num_tram_documentario { get; set; }
        public string indicativo_oficio { get; set; }
        public string asunto { get; set; }
        public int? folios { get; set; }
        public string observaciones { get; set; }
        public string fecha_recepcion { get; set; }
        public string prioridad { get; set; }
        public string usuario { get; set; }
        public DateTime auditmod { get; set; }
        public string estado_requisito { get; set; }
        public string fecha2 { get; set; }
        public int? coddep { get; set; }
        public string obsfin { get; set; }
        public string fecha3 { get; set; }
        public string modificacion { get; set; }
        public string referencia { get; set; }
        public string fecha_max_plazo { get; set; }
        public int? coddep_responsable { get; set; }

        //============================================================================
        // CAMPOS AUXILIARES
        //============================================================================
        public string cod_estado_docinterno { get; set; }
        public string clave { get; set; }
        public string tipo_hoja_tramite
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.num_tram_documentario) ? "I" : "E";
            }
        }
        public string numero_hoja_tramite
        {
            get
            {
                return this.contador_interno != null && this.contador_interno.Count > 0 ?
                       this.contador_interno[0].hoja_tramite : this.num_tram_documentario;
            }
        }
        public virtual EstadoDocumentoResponse estado_documento { get; set; }
        public virtual PersonaResponse persona { get; set; }
        public virtual ClaseDocumentoResponse clase_documento_interno { get; set; }
        public virtual ICollection<MovimientoDocumentoResponse> movimiento_documento { get; set; }
        public virtual ICollection<RequisitoTupaResponse> requisitos { get; set; }
        public virtual TupaResponse tupa { get; set; }
        public virtual ICollection<AnexoResponse> anexos { get; set; }
        public virtual IList<ContadorInternoResponse> contador_interno { get; set; }
        public virtual IList<DocumentoCopiaResponse> copias { get; set; }
        public virtual DependenciaResponse dependencia_inicial { get; set; }
        public virtual DependenciaResponse dependencia_actual { get; set; }
        public virtual bool aceptado_dependencia_inicial { get; set; }
        public int cant_copias { get; set; }
        public int cant_adjuntos { get; set; }

    }
}
