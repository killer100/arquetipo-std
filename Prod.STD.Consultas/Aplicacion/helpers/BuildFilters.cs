using Prod.STD.Entidades.Documento;
using Prod.STD.Entidades.DocumentoEscaneado;
using Prod.STD.Entidades.DocumentoIngresado;
using Prod.STD.Enumerados;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Modelo = Prod.STD.Datos.Modelo;

namespace Prod.STD.Consultas.Aplicacion.helpers
{
    public class BuildFilters
    {
        public static Expression<Func<Modelo.documento, bool>> BuildFiltersDocumento(DocumentoFilter filters)
        {
            Expression<Func<Modelo.documento, bool>> _where = x => x.ID_DOCUMENTO > 14784048 &&

            (x.ID_ESTADO_DOCUMENTO != ESTADO_DOCUMENTO.ELIMINADO) &&

            (string.IsNullOrEmpty(filters.indicativo_oficioClean) || x.INDICATIVO_OFICIO.Contains(filters.indicativo_oficioClean.Trim())) &&

            (string.IsNullOrEmpty(filters.num_tram_documentarioClean) || x.NUM_TRAM_DOCUMENTARIO.Contains(filters.num_tram_documentarioClean.Trim())) &&

            (filters.id_tipos_documento == null || filters.id_tipos_documento.Contains(x.ID_TIPO_DOCUMENTO)) &&

            (filters.id_clases_documento == null || filters.id_clases_documento.Contains(x.ID_CLASE_DOCUMENTO_INTERNO)) &&

            (filters.id_tupas == null || filters.id_tupas.Contains(x.ID_TUP)) &&

            (filters.id_estados_documento == null || filters.id_estados_documento.Contains(x.ID_ESTADO_DOCUMENTO)) &&

            (string.IsNullOrEmpty(filters.asuntoClean) || x.ASUNTO.Contains(filters.asuntoClean)) &&

            (filters.fecha_registro_inicio == null || x.AUDITMOD >= filters.fecha_registro_inicio.Value.Date) &&

            (filters.fecha_registro_fin == null || x.AUDITMOD < filters.fecha_registro_fin.Value.Date.AddDays(1));

            return _where;
        }

        public static Expression<Func<Modelo.vw_documentos_sitradoc_digitalizacion, bool>> BuildFiltersDocumentosIngresados(DocumentoIngresadoFilter filters)
        {
            Expression<Func<Modelo.vw_documentos_sitradoc_digitalizacion, bool>> where = x =>
                (filters.coddep == null || x.coddep == filters.coddep) &&
                (filters.fecha_inicio == null || x.fecha_registro >= filters.fecha_inicio.Value.Date) &&
                (filters.fecha_fin == null || x.fecha_registro < filters.fecha_fin.Value.Date.AddDays(1)) &&
                (filters.estado == null || (filters.estado == 1 ? x.documento_digitalizado == null : x.documento_digitalizado != null));
            return where;
        }

        public static Expression<Func<Modelo.vw_documentos_sitradoc, bool>> BuildFiltersDocumentosEscaneados(DocumentoEscaneadoFilter filters)
        {
            Expression<Func<Modelo.vw_documentos_sitradoc, bool>> where = x =>
                (filters.coddep == null || x.coddep == filters.coddep) &&
                (filters.fecha_inicio == null || x.fecha_registro >= filters.fecha_inicio.Value.Date) &&
                (filters.fecha_fin == null || x.fecha_registro < filters.fecha_fin.Value.Date.AddDays(1)) &&
                (filters.estado == null || (filters.estado == 1 ? x.documento_estado == null : x.documento_estado != null));
            return where;
        }
    }
}
