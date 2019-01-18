using Prod.STD.Entidades._Base;
using Prod.STD.Entidades.Comun;
using Prod.STD.Entidades.DocumentoAdjunto;
using Prod.STD.Entidades.DocumentoCopia;
using Prod.STD.Entidades.DocumentoDepDestino;
using Prod.STD.Entidades.DocumentoReferencia;
using Prod.STD.Entidades.TipoTratamiento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.Documento
{
    public class DocumentoRequest : BaseRequest
    {
        public int? id_documento { get; set; }
        public int? id_tup { get; set; }
        public string num_tram_documentario { get; set; }
        public string indicativo_oficio { get; set; }
        public DateTime? fecha_recepcion { get; set; }
        public string asunto { get; set; }
        public string referencia { get; set; }
        public int? id_clase_documento_interno { get; set; }
        public int? folios { get; set; }
        public string observaciones { get; set; }
        public int? oficina_derivada { get; set; }
        public int? id_persona { get; set; }

        #region Documento Interno
        public bool es_documento_respuesta { get; set; }
        public string tipo_hoja_tramite { get; set; }
        public bool tiene_adjuntos { get; set; }
        public bool si_requiere_respuesta { get; set; }
        public bool es_urgente { get; set; }
        public int? codigo_dependencia { get; set; }
        #endregion
        public int year { get; set; }
        public List<RequisitoTupaRequest> requisitos { get; set; }
        public List<DocumentoCopiaRequest> copias { get; set; }
        public List<DocumentoReferenciaRequest> referencias { get; set; }
        public List<DocumentoDepDestinoRequest> coddeps_destino { get; set; }
        public List<DocumentoAdjuntoRequest> adjuntos { get; set; }
        public List<TipoTratamientoRequest> acciones { get; set; }
    }
}
