using AutoMapper;
using Prod.STD.Consultas.Aplicacion.Interface;
using Prod.STD.Core;
using Prod.STD.Datos;
using Prod.STD.Entidades.Documento;
using Release.Helper.Data.ICore;
using System;
using System.Collections.Generic;
using System.Text;
using Modelo = Prod.STD.Datos.Modelo;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Release.Helper.Pagination;
using Prod.STD.Entidades.Comun;
using Prod.STD.Enumerados;
using System.Linq.Expressions;
using Prod.STD.Core.Resources;
using Prod.STD.Core.Extensions;
using Prod.STD.Entidades.DocumentoIngresado;
using Prod.STD.Consultas.Aplicacion.helpers;
using Prod.STD.Entidades.DocumentoEscaneado;
using Prod.STD.Entidades.DetalleHojaRuta;
using Prod.STD.Entidades.FlujoDocumentario;

namespace Prod.STD.Consultas.Aplicacion
{
    public class DocumentoAplicacion : IDocumentoAplicacion
    {
        #region Private Fields

        private readonly IMapper _mapper;
        private IContext _context;
        private IUnitOfWork _uow;

        #endregion Private Fields

        #region Public Constructors

        public DocumentoAplicacion(IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _uow = unitOfWork;
            _context = _uow.Context;
            _mapper = mapper;

        }

        #endregion Public Constructors

        #region Public Methods

        #region Gestión Interna
        public PagedResponse<DocumentoResponse> GetDocumentosGestionInterna(DocumentoFilter filters, DocumentoOptions options)
        {
            var _where = BuildFilters.BuildFiltersDocumento(filters);

            var movimientos = _context.Query<Modelo.movimiento_documento>();
            var persona = _context.Query<Modelo.v_persona>().Select(x => new { x.ID });
            Expression<Func<Modelo.documento, bool>> _custom = x =>
                (movimientos.Any(m => (filters.mvEnviado == null || m.enviado == filters.mvEnviado) &&
                                      (filters.mvDerivado == null || m.derivado == filters.mvDerivado) &&
                                      (filters.mvFinalizado == null || m.finalizado == filters.mvFinalizado) &&
                                      m.ID_DEPENDENCIA_DESTINO == filters.coddep &&
                                      (filters.isDocumentoRecibido == null || ((m.AUDIT_REC != null) == filters.isDocumentoRecibido)) &&
                                      (filters.estado_documento_interno != (int)ESTADODOC_INTERNO.FINALIZADO || m.finalizado == 1) &&
                                      (filters.estado_documento_interno != (int)ESTADODOC_INTERNO.DELEGADO || m.codigo_trabajador != null) &&
                                      m.AUDIT_MOD >= Convert.ToDateTime("01/01/2014") &&
                                      x.ID_DOCUMENTO == m.ID_DOCUMENTO
            ));

            _where = _where.AndAlso(_custom);
            var query = _context.Query<Modelo.documento>();
            query = BuildOptionsDocumento(query, options);
            query = query.Where(_where).OrderByDescending(x => x.AUDITMOD).AsQueryable();
            var page = query.PagedResponse<Modelo.documento, DocumentoResponse>(filters, _mapper);
            return page;
        }
        public int GetDocumentoIdFromHojaTramite(DocumentoFilter filtro)
        {
            var query = _context.Query<Modelo.documento>();
            var queryContInterno = _context.Query<Modelo.dat_contador_interno>();
            int idDocumento = 0;
            if (filtro.tipo_hoja_tramite == "I")
            {
                queryContInterno = queryContInterno.Where(x => $"{String.Format("{0:00000000}", x.contador)}-{x.fecha_registro.Year}" == filtro.num_tram_documentario);
                idDocumento = queryContInterno.Count() == 0 ? 0 : queryContInterno.FirstOrDefault().id_documento;
            }
            if (filtro.tipo_hoja_tramite == "E")
            {
                query = query.Where(x => x.NUM_TRAM_DOCUMENTARIO == filtro.num_tram_documentario);
                idDocumento = query.Count() == 0 ? 0 : query.FirstOrDefault().ID_DOCUMENTO;
            }
            return idDocumento;
        }
        #endregion
        public DetalleHojaRutaResponse GetDetalleHojaDeRuta(int id_documento, string tipo)
        {

            DocumentoHojaTramiteResponse documento = null;

            switch (tipo)
            {
                case "I":
                    documento = _uow.p_DOCUMENTO_GET_HOJA_TRAMITE_INTERNA(id_documento);
                    break;
                case "E":
                    documento = _uow.p_DOCUMENTO_GET_HOJA_TRAMITE_EXTERNA(id_documento);
                    break;
            }

            if (documento == null)
                xHelper.AbortWithResourceNotFound();

            return new DetalleHojaRutaResponse
            {
                documento = documento,
                rutas = _uow.p_DOCUMENTO_GET_HOJA_RUTA(id_documento).ToList()
            };
        }

        public DocumentoResponse GetDocumentoComun(int id_documento, DocumentoOptions options)
        {

            var query = _context.Query<Modelo.documento>();

            query = BuildOptionsDocumento(query, options);

            var documento = query.FirstOrDefault(x => x.ID_DOCUMENTO == id_documento);

            if (documento == null)
                xHelper.Abort(404, Messages.RESOURCE_NOT_FOUND);

            var response = _mapper.Map<Modelo.documento, DocumentoResponse>(documento);

            if (options.withRequisitos)
            {
                response.requisitos = GetRequisitos(documento.ID_DOCUMENTO, documento.ID_TUP);
            }

            if (response.anexos != null && response.anexos.Count > 0)
                response.anexos = response.anexos.Where(x => x.estado_adjunto == ESTADO_ADJUNTO.ACTIVO).ToList();

            if (response.copias != null && response.copias.Count > 0)
                response.copias = response.copias.Where(x => x.estado == ESTADO_DOCUMENTO_COPIA.ACTIVO).ToList();


            return response;
        }
        public PagedResponse<DocumentoEscaneadoResponse> GetDocumentosEscaneadosMesaPartes(DocumentoEscaneadoFilter filters)
        {
            var where = BuildFilters.BuildFiltersDocumentosEscaneados(filters);

            var query = _context.Query<Modelo.vw_documentos_sitradoc>().Where(where);

            query = query.OrderByDescending(x => x.id_documento);

            var page = query.PagedResponse<Modelo.vw_documentos_sitradoc, DocumentoEscaneadoResponse>(filters, _mapper);

            page.Data.ToList().ForEach(x =>
            {
                var dep = x.coddep == null ? null : _context.Query<Modelo.vw_dat_dependencia>().FirstOrDefault(d => d.CODIGO_DEPENDENCIA == x.coddep.Value);
                x.dependencia = _mapper.Map<Modelo.vw_dat_dependencia, DependenciaResponse>(dep);
                x.esTupa = _context.Query<Modelo.documento>().Any(doc => doc.ID_DOCUMENTO == x.id_documento && doc.ID_TUP != null);
            });

            return page;

        }

        public PagedResponse<DocumentoIngresadoResponse> GetDocumentosIngresadosMesaPartes(DocumentoIngresadoFilter filters)
        {
            var where = BuildFilters.BuildFiltersDocumentosIngresados(filters);

            var query = _context.Query<Modelo.vw_documentos_sitradoc_digitalizacion>().Where(where);

            query = query.OrderByDescending(x => x.id_documento);

            var page = query.PagedResponse<Modelo.vw_documentos_sitradoc_digitalizacion, DocumentoIngresadoResponse>(filters, _mapper);

            page.Data.ToList().ForEach(x =>
            {
                var dep = x.coddep == null ? null : _context.Query<Modelo.vw_dat_dependencia>().FirstOrDefault(d => d.CODIGO_DEPENDENCIA == x.coddep.Value);
                x.dependencia = _mapper.Map<Modelo.vw_dat_dependencia, DependenciaResponse>(dep);
                x.esTupa = _context.Query<Modelo.documento>().Any(doc => doc.ID_DOCUMENTO == x.id_documento && doc.ID_TUP != null);
            });

            return page;
        }

        public PagedResponse<DocumentoResponse> GetDocumentosMesaPartes(DocumentoFilter filters, DocumentoOptions options)
        {
            var _where = BuildFilters.BuildFiltersDocumento(filters);

            var personas = _context.Query<Modelo.v_persona>().Select(x => new { x.ID, razon_social_format = (x.NOMBRES + " " + x.APELLIDOS + " " + x.RAZON_SOCIAL).Trim() });

            var trabajadores = _context.Query<Modelo.vw_dat_trabajador>().Select(x => new { x.CODIGO_DEPENDENCIA, x.EMAIL });

            var dependencias_consulta = new int[] { DEPENDENCIA_PRODUCE.OGACI, DEPENDENCIA_PRODUCE.OGDA, DEPENDENCIA_PRODUCE.OACI, DEPENDENCIA_PRODUCE.OACI_2 };

            var documentos = _context.Query<Modelo.documento>().Select(d => new { d.ID_DOCUMENTO, d.ID_CLASE_DOCUMENTO_INTERNO, d.INDICATIVO_OFICIO });

            var movimientos = _context.Query<Modelo.movimiento_documento>().Select(m => new { m.ID_DOCUMENTO, m.ID_OFICIO, m.ID_DEPENDENCIA_DESTINO });

            var resoluciones = _context.Query<Modelo.resolucion>().Select(r => new { r.id_documento, r.id_tipo_resolucion, r.nro_resol });

            Expression<Func<Modelo.documento, bool>> _custom = x =>
                (string.IsNullOrEmpty(filters.razon_socialClean) || personas.Any(p => p.razon_social_format.Trim().Contains(filters.razon_socialClean) && x.ID_PERSONA == p.ID)) &&

                (filters.id_clase_documento_hijo == null || string.IsNullOrEmpty(filters.indicativo_oficio_hijo) ||
                        movimientos.Any(m => m.ID_DOCUMENTO == x.ID_DOCUMENTO &&
                            documentos.Any(d =>
                                d.ID_DOCUMENTO == m.ID_OFICIO &&
                                d.ID_CLASE_DOCUMENTO_INTERNO == filters.id_clase_documento_hijo &&
                                d.INDICATIVO_OFICIO.Contains(filters.indicativo_oficio_hijo)
                            )
                       )
                ) &&

                (filters.oficina_derivada == null ||
                    movimientos.Any(m =>
                        x.ID_DOCUMENTO == m.ID_DOCUMENTO &&
                        m.ID_OFICIO == null &&
                        m.ID_DEPENDENCIA_DESTINO == filters.oficina_derivada.Value
                    )
                ) &&

                (filters.id_tipo_resolucion == null || string.IsNullOrEmpty(filters.numero_resolucion) ||
                        resoluciones.Any(r => r.id_documento == x.ID_DOCUMENTO && r.id_tipo_resolucion == filters.id_tipo_resolucion && r.nro_resol.Contains(filters.numero_resolucion))) &&

                (trabajadores.Any(t => t.EMAIL == x.USUARIO && dependencias_consulta.Contains(t.CODIGO_DEPENDENCIA)));

            _where = _where.AndAlso(_custom);

            var query = _context.Query<Modelo.documento>();

            query = BuildOptionsDocumento(query, options);

            query = query.Where(_where).OrderByDescending(x => x.AUDITMOD).AsQueryable();

            query = (from a in query
                     join b in _context.Query<Modelo.documento_cont>() on a.ID_DOCUMENTO equals b.ID_DOCUMENTO into docs
                     from b in docs.DefaultIfEmpty()
                     select a.setDocumentoCont(b));

            var page = query.PagedResponse<Modelo.documento, DocumentoResponse>(filters, _mapper);

            page.Data.ToList().ForEach(x =>
            {
                var mov_inicial = _context.Query<Modelo.movimiento_documento>()
                .Include(m => m.dependencia_destino)
                .FirstOrDefault(m => m.ID_DOCUMENTO == x.id_documento && m.ID_OFICIO == null);
                if (mov_inicial != null)
                {
                    x.aceptado_dependencia_inicial = mov_inicial.AUDIT_REC != null;
                    x.dependencia_inicial = _mapper.Map<Modelo.vw_dat_dependencia, DependenciaResponse>(mov_inicial.dependencia_destino);
                }

                var mov_actual = _context.Query<Modelo.movimiento_documento>()
                .Include(m => m.dependencia_destino).OrderByDescending(m => m.ID_MOVIMIENTO_DOCUMENTO)
                .FirstOrDefault(m => m.ID_DOCUMENTO == x.id_documento);
                if (mov_actual != null)
                {
                    x.dependencia_actual = _mapper.Map<Modelo.vw_dat_dependencia, DependenciaResponse>(mov_actual.dependencia_destino);
                }
            });

            return page;
        }
        public FlujoDocumentarioResponse GetFlujoDocumentario(int id_documento, string tipo)
        {
            DocumentoHojaTramiteResponse documento = null;

            switch (tipo)
            {
                case "I":
                    documento = _uow.p_DOCUMENTO_GET_HOJA_TRAMITE_INTERNA(id_documento);
                    break;
                case "E":
                    documento = _uow.p_DOCUMENTO_GET_HOJA_TRAMITE_EXTERNA(id_documento);
                    break;
            }

            if (documento == null)
                xHelper.AbortWithResourceNotFound();

            return new FlujoDocumentarioResponse
            {
                documento = documento,
                flujoDependencias = _uow.p_DOCUMENTO_FLUJO_GET_FLUJO_DEPENDENCIAS(id_documento).ToList(),
                flujoTrabajadores = _uow.p_DOCUMENTO_FLUJO_GET_FLUJO_TRABAJADORES(id_documento).ToList(),
                correspondencias = _uow.p_DOCUMENTO_FLUJO_GET_CORRESPONDENCIAS(id_documento).ToList(),
                resoluciones = _uow.p_DOCUMENTO_FLUJO_GET_RESOLUCIONES(id_documento).ToList(),
                anexos = _uow.p_DOCUMENTO_FLUJO_GET_ANEXOS(id_documento).ToList()
            };
        }

        public ICollection<DependenciaResponse> GetOficinasFinalizadas(int id_documento)
        {
            var dependencias = _context.Query<Modelo.movimiento_documento>().Include(x => x.dependencia_destino).Where(
                    x => x.ID_DOCUMENTO == id_documento && x.finalizado == 1 && x.ID_DEPENDENCIA_DESTINO != 0
                ).OrderByDescending(x => x.AUDIT_MOD).Select(x => x.dependencia_destino).ToList();

            return _mapper.Map<IList<Modelo.vw_dat_dependencia>, IList<DependenciaResponse>>(dependencias);
        }

        public ICollection<DependenciaResponse> GetOficinasPendientes(int id_documento)
        {
            var dependencias = _context.Query<Modelo.movimiento_documento>().Include(x => x.dependencia_destino).Where(
                    x => x.ID_DOCUMENTO == id_documento && x.derivado == 0 && x.finalizado == 0 && x.ID_DEPENDENCIA_DESTINO != 0
                ).OrderByDescending(x => x.AUDIT_MOD).Select(x => x.dependencia_destino).ToList();

            return _mapper.Map<IList<Modelo.vw_dat_dependencia>, IList<DependenciaResponse>>(dependencias);
        }
        public PagedResponse<ReporteDocumentoEscaneadoResponse> GetReportesDocumentosEscaneados(PagedRequest request)
        {
            var query = _context.Query<Modelo.vw_listado_reportes_documentos>();

            query = query.OrderByDescending(x => DateTime.Parse(x.fecha_registro));

            var page = query.PagedResponse<Modelo.vw_listado_reportes_documentos, ReporteDocumentoEscaneadoResponse>(request, _mapper);

            return page;
        }

        public PagedResponse<ReporteDocumentoIngresadoResponse> GetReportesDocumentosIngresados(PagedRequest request)
        {
            var query = _context.Query<Modelo.vw_listado_reportes_digitalizados>();

            query = query.OrderByDescending(x => DateTime.Parse(x.fecha_registro));

            var page = query.PagedResponse<Modelo.vw_listado_reportes_digitalizados, ReporteDocumentoIngresadoResponse>(request, _mapper);

            return page;
        }

        #endregion Public Methods

        //============================================================================
        // VERIFICAR PERMISOS
        //============================================================================

        #region CONSULTAS PARA VERIFICAR PERMISOS

        public bool MesaPartesPuedeAdjuntar(int id_documento)
        {
            var documento = _context.Query<Modelo.documento>()
                .Where(x => x.ID_DOCUMENTO == id_documento)
                .FirstOrDefault();

            if (documento == null)
                return false;

            return documento.ID_ESTADO_DOCUMENTO != ESTADO_DOCUMENTO.FINALIZADO;
        }

        public bool MesaPartesPuedeAgregarCopia(int id_documento)
        {
            var movimiento = _context.Query<Modelo.movimiento_documento>()
                .Where(x => x.ID_DOCUMENTO == id_documento && x.ID_OFICIO == null)
                .FirstOrDefault();

            if (movimiento == null)
                return true;

            return movimiento.AUDIT_REC == null;
        }

        public bool MesaPartesPuedeAnular(int id_documento)
        {
            var movimiento = _context.Query<Modelo.movimiento_documento>()
                .Where(x => x.ID_DOCUMENTO == id_documento && x.ID_OFICIO == null)
                .FirstOrDefault();

            if (movimiento == null)
                return true;

            return movimiento.AUDIT_REC == null;
        }

        public bool MesaPartesPuedeLevantarObservaciones(int id_documento)
        {
            var documento = _context.Query<Modelo.documento>()
                .Where(x => x.ID_DOCUMENTO == id_documento)
                .FirstOrDefault();

            if (documento == null)
                return false;

            return documento.ID_ESTADO_DOCUMENTO == ESTADO_DOCUMENTO.OBSERVADO;
        }

        public bool MesaPartesPuedeModificar(int id_documento)
        {
            var movimiento = _context.Query<Modelo.movimiento_documento>()
                .Where(x => x.ID_DOCUMENTO == id_documento && x.ID_OFICIO == null)
                .FirstOrDefault();

            if (movimiento == null)
                return true;

            return movimiento.AUDIT_REC == null;
        }
        public bool MesaPartesPuedeReactivar(int id_documento)
        {
            var documento = _context.Query<Modelo.documento>()
                .Where(x => x.ID_DOCUMENTO == id_documento)
                .FirstOrDefault();

            if (documento == null)
                return false;

            return documento.ID_ESTADO_DOCUMENTO == ESTADO_DOCUMENTO.FINALIZADO;
        }
        #endregion

        #region HELPERS

        private IQueryable<Modelo.documento> BuildOptionsDocumento(IQueryable<Modelo.documento> query, DocumentoOptions options)
        {
            if (options.withEstado)
                query = query.Include(x => x.estado_documento);

            if (options.withPersona)
                query = query.Include(x => x.persona);

            if (options.withHojaTramite)
                query = query.Include(x => x.contador_interno);

            if (options.withClaseDocumento)
                query = query.Include(x => x.clase_documento_interno);

            if (options.withMovimientos)
            {
                query = query.Include(x => x.movimiento_documento).ThenInclude(x => x.dependencia_origen);
                query = query.Include(x => x.movimiento_documento).ThenInclude(x => x.dependencia_destino);
            }

            if (options.withTupa)
                query = query.Include(x => x.tupa);

            if (options.withAnexos)
            {
                query = query.Include(x => x.anexos).ThenInclude(x => x.persona)
                             .Include(x => x.anexos).ThenInclude(x => x.tipo_anexo)
                             .Include(x => x.anexos).ThenInclude(x => x.persona_destino).ThenInclude(x => x.dependencia);
            }
            if (options.withCopias)
            {
                query = query.Include(x => x.copias).ThenInclude(x => x.dependencia);
            }
            return query;
        }

        private ICollection<RequisitoTupaResponse> GetRequisitos(int id_documento, int? id_tupa)
        {
            if (id_tupa == null)
                return null;

            var requisitos = _context.Query<Modelo.vw_dat_requisito_tupa>()
                .Where(x => x.ID_TUPA == id_tupa && x.ESTADO == ESTADO_REQUISITO_TUPA.ACTIVO);
            var osbervaciones = _context.Query<Modelo.observaciones_requisitos_tramite>()
                .Where(x => x.ID_DOCUMENTO == id_documento && x.ESTADO != ESTADO_OBSERVACION_REQUISITO.ELIMINADO && x.ID_REQUISITO_TUPA != 0);

            var result = (from requisito in requisitos
                          join observacion in osbervaciones on requisito.ID_REQUISITO equals observacion.ID_REQUISITO_TUPA into Details
                          from req in Details.DefaultIfEmpty()
                          select new RequisitoTupaResponse
                          {
                              id_requisito = requisito.ID_REQUISITO,
                              descripcion = requisito.DESCRIPCION,
                              id_tupa = requisito.ID_TUPA,
                              numero_requisito = requisito.NUMERO_REQUISITO,
                              estado = requisito.ESTADO,
                              id_tipo_requisito = requisito.ID_TIPO_REQUISITO,
                              valor_uit = requisito.VALOR_UIT,
                              monto = requisito.MONTO,
                              estado_observacion = req.ESTADO == null || req.ESTADO == ESTADO_OBSERVACION_REQUISITO.SUBSANADO ? true : false,
                              observaciones = req.OBSERVACIONES
                          }).ToList();

            var observacion_general = _context.Query<Modelo.observaciones_requisitos_tramite>()
                .Where(x => x.ID_DOCUMENTO == id_documento && x.ID_REQUISITO_TUPA == 0 && x.ESTADO != ESTADO_OBSERVACION_REQUISITO.ELIMINADO).FirstOrDefault();

            if (observacion_general == null)
            {
                return result.ToList();
            }

            result.Add(new RequisitoTupaResponse
            {
                observaciones = observacion_general.OBSERVACIONES
            });

            return result;
        }


        #endregion
    }

}
