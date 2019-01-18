using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Prod.STD.Datos.Modelo;
using Prod.STD.Entidades.Anexo;
using Prod.STD.Entidades.Comun;
using Prod.STD.Entidades.Documento;
using Prod.STD.Entidades.DocumentoCont;
using Prod.STD.Entidades.DocumentoEscaneado;
using Prod.STD.Entidades.DocumentoIngresado;
using Prod.STD.Entidades.EstadoDocumento;
using Prod.STD.Entidades.MovimientoDocumento;

namespace Prod.STD.Core.Mapping
{
    public class STDProfile : Profile
    {
        public STDProfile()
        {
            CreateMap<clase_documento_interno, ClaseDocumentoResponse>();

            CreateMap<movimiento_documento, MovimientoDocumentoResponse>();

            CreateMap<documento, DocumentoResponse>();

            CreateMap<estado_documento, EstadoDocumentoResponse>();

            CreateMap<vw_dat_tupa, TupaResponse>();

            CreateMap<tipo_resolucion, TipoResolucionResponse>();

            CreateMap<vw_dat_clase_tupa, ClaseTupaResponse>();

            CreateMap<vw_dat_dependencia, DependenciaResponse>();

            CreateMap<v_persona, PersonaResponse>();

            CreateMap<vw_dat_requisito_tupa, RequisitoTupaResponse>();

            CreateMap<tipo_anexo, TipoAnexoResponse>();

            CreateMap<anexo, AnexoResponse>();

            CreateMap<vw_documentos_sitradoc_digitalizacion, DocumentoIngresadoResponse>();

            CreateMap<vw_documentos_sitradoc, DocumentoEscaneadoResponse>();

            CreateMap<vw_listado_reportes_digitalizados, ReporteDocumentoIngresadoResponse>();

            CreateMap<vw_listado_reportes_documentos, ReporteDocumentoEscaneadoResponse>();
        }
    }
}
