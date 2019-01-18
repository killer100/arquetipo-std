using Prod.STD.Entidades._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.DocumentoIngresado
{
    public class ReporteDocumentosIngresadosRequest
    {
        public IList<DocumentoIngresadoRequest> documentos { get; set; }

        public string observaciones { get; set; }

        public int? codigo_dependencia_entrega { get; set; }

        public int? codigo_trabajador_entrega { get; set; }

        public int? codigo_dependencia_recibido { get; set; }

        public int? codigo_trabajador_recibido { get; set; }

        public string user { get; set; }

        public string ip { get; set; }

        public int correlativo { get; set; }

        public int id_reporte { get; set; }
    }
}
