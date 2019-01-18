using Release.Helper.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Documento
{
    public class DocumentoFilter : PagedRequest
    {
        public int? id_documento { get; set; }

        public string indicativo_oficio { get; set; }
        public string num_tram_documentario { get; set; }
        public ICollection<int?> id_tipos_documento { get; set; }

        public ICollection<int?> id_clases_documento { get; set; }

        public ICollection<int?> id_tupas { get; set; }

        public string asunto { get; set; }

        public string razon_social { get; set; }

        public DateTime? fecha_registro_inicio { get; set; }

        public DateTime? fecha_registro_fin { get; set; }

        public ICollection<int?> id_estados_documento { get; set; }

        public string tipo_hoja_tramite { get; set; }

        public int? id_clase_documento_hijo { get; set; }

        public string indicativo_oficio_hijo { get; set; }

        public int? oficina_derivada { get; set; }

        public int? id_tipo_resolucion { get; set; }

        public string numero_resolucion { get; set; }

        public int estado_documento_interno { get; set; }
        public int? mvEnviado { get; set; }
        public int? mvDerivado { get; set; }
        public int? mvFinalizado { get; set; }
        public bool? isDocumentoRecibido { get; set; }
        public int coddep { get; set; }

        #region CAMPOS CALCULADOS
        public string asuntoClean
        {
            get
            {
                return string.IsNullOrEmpty(asunto) ? null : asunto.Trim();
            }
        }

        public string indicativo_oficioClean
        {
            get
            {
                return string.IsNullOrEmpty(indicativo_oficio) ? null : indicativo_oficio.Trim();
            }
        }

        public string num_tram_documentarioClean
        {
            get
            {
                return string.IsNullOrEmpty(num_tram_documentario) ? null : num_tram_documentario.Trim();
            }
        }

        public string razon_socialClean
        {
            get
            {
                return string.IsNullOrEmpty(razon_social) ? null : razon_social.Trim();
            }
        }

        #endregion

    }
}
