using AutoMapper;
using Prod.STD.Comandos.Aplicacion.Interface;
using Prod.STD.Comandos.Aplicacion.Validacion;
using Prod.STD.Core;
using Prod.STD.Core.Resources;
using Prod.STD.Datos;
using Prod.STD.Entidades.Documento;
using Release.Helper.Data.ICore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Prod.STD.Comandos.Aplicacion.Proceso;
using Modelo = Prod.STD.Datos.Modelo;
using Microsoft.EntityFrameworkCore;
using Prod.STD.Enumerados;
using Prod.STD.Entidades.DocumentoIngresado;
using Prod.STD.Entidades.DocumentoEscaneado;
using Prod.ServiciosExternos;
using Prod.ServiciosExternos.Entidades;

namespace Prod.STD.Comandos.Aplicacion
{
    public class DocumentoAplicacion : IDocumentoAplicacion
    {
        #region Private Fields

        private readonly DocumentoProceso _documentoProceso;
        private readonly DocumentoValidacion _documentoValidacion;
        private readonly IMapper _mapper;
        private readonly IEmailSender _emailSender;
        private IContext _context;
        private IUnitOfWork _uow;

        #endregion Private Fields

        #region Public Constructors

        public DocumentoAplicacion(IUnitOfWork unitOfWork,
            IMapper mapper,
            DocumentoValidacion documentoValidacion,
            DocumentoProceso documentoProceso,
            IEmailSender emailSender)
        {
            _uow = unitOfWork;
            _context = _uow.Context;
            _documentoValidacion = documentoValidacion;
            _documentoProceso = documentoProceso;
            _mapper = mapper;
            _emailSender = emailSender;
        }

        #endregion Public Constructors

        #region Public Methods

        public void AgregarCopias(DocumentoRequest request)
        {
            var errors = _documentoValidacion.ValidarCopiasDocumento(request);
            if (errors.Any())
                xHelper.AbortWithValidationErrors(errors);

            try
            {
                _uow.BeginTransaction();

                var documento = _context.Query<Modelo.documento>().Include(x => x.movimiento_documento).Include(x => x.copias)
                .FirstOrDefault(x => x.ID_DOCUMENTO == request.id_documento);

                var documento_cont = _context.Query<Modelo.documento_cont>().FirstOrDefault(x => x.ID_DOCUMENTO == request.id_documento);

                if (documento == null)
                    throw new ResourceNotFoundException();

                var coddeps = documento.copias == null ?
                    new List<int>() :
                    documento.copias.Where(x => x.ESTADO == ESTADO_DOCUMENTO_COPIA.ACTIVO).Select(x => x.CODDEP);

                var intersect = request.copias.Where(x => x.coddep != null).Select(x => x.coddep.Value).Intersect(coddeps);

                request.copias.Where(x => x.coddep != null && !intersect.Contains(x.coddep.Value)).ToList().ForEach(x =>
                {
                    documento.copias.Add(new Modelo.dat_documento_copia
                    {
                        LEIDO = 0,
                        CODDEP = x.coddep.Value,
                        ESTADO = ESTADO_DOCUMENTO_COPIA.ACTIVO,
                        AUDITCREA = DateTime.Now
                    });
                });

                _context.Update(documento);
                _uow.Save();

                //============================================================================
                // ACTUALIZANDO TABLA DOCUMENTO_CONT
                //============================================================================

                if (documento_cont != null)
                {
                    documento_cont.CANT_COPIAS = documento.copias.Where(x => x.ESTADO == ESTADO_DOCUMENTO_COPIA.ACTIVO).Count();
                    _context.Update(documento_cont);
                    _uow.Save();
                }
                else
                {
                    _uow.InsertarDocumentoCont(documento.ID_DOCUMENTO);
                }

                _uow.Commit();
            }
            catch (ResourceNotFoundException e)
            {
                _uow.Rollback();
                xHelper.AbortWithResourceNotFound();
            }
            catch (Exception e)
            {
                _uow.Rollback();
                xHelper.AbortWithInternalError();
            }
        }

        public void Anular(DocumentoRequest request)
        {
            var errors = _documentoValidacion.ValidarAnularDocumento(request);
            if (errors.Any())
                xHelper.AbortWithValidationErrors(errors);

            try
            {
                _uow.BeginTransaction();
                _documentoProceso.EjecutaAnular(request);
                _uow.Commit();
            }
            catch (ResourceNotFoundException e)
            {
                _uow.Rollback();
                xHelper.AbortWithResourceNotFound();
            }
            catch (Exception e)
            {
                _uow.Rollback();
                xHelper.AbortWithInternalError();
            }

        }

        public string GenerarReporteDocumentosEscaneados(ReporteDocumentosEscaneadosRequest request)
        {
            try
            {
                _uow.BeginTransaction();

                request = _documentoProceso.EjecutarGeneraReporteDocumentosEscaneados(request);

                request.documentos.ToList().ForEach(x =>
                {
                    _uow.p_DOCUMENTO_ESTADO_Crud(
                        x.id_documento.Value,
                        x.id_anexo.Value,
                        request.username,
                        request.ip_address,
                        1,
                        request.id_reporte);
                });

                var coddep_dependencia_envio = request.documentos.FirstOrDefault().coddep;

                var usuario_envio = _context.Query<Modelo.vw_dat_trabajador>().FirstOrDefault(x => x.EMAIL == request.username);
                var usuario_recibido = _context.Query<Modelo.vw_dat_trabajador>().FirstOrDefault(x => x.CODIGO_DEPENDENCIA == coddep_dependencia_envio && x.ESTADO == "ACTIVO" && x.DIRECTOR == 6);
                var dependencia_recibido = _context.Query<Modelo.vw_dat_dependencia>().FirstOrDefault(x => x.CODIGO_DEPENDENCIA == coddep_dependencia_envio);

                var emailRequest = new EmailRequest
                {
                    //to = $"{usuario_recibido.EMAIL}@produce.gob.pe",
                    to = "jrodriguez@produce.gob.pe;mgarciach@produce.gob.pe",
                    isBodyHtml = true,
                    subject = "STD - Nuevo reporte generado"
                };

                var sr = _emailSender.Send("NotificacionReporteDocumentosEscaneados", emailRequest, new
                {
                    usuario_envio = $"{usuario_envio.NOMBRES_TRABAJADOR} {usuario_envio.APELLIDOS_TRABAJADOR}",
                    usuario_recibido = $"{usuario_recibido.NOMBRES_TRABAJADOR} {usuario_recibido.APELLIDOS_TRABAJADOR}",
                    dependencia_recibido = $"{dependencia_recibido.DEPENDENCIA}",
                    cantidad = request.documentos.Count(),
                    numero_reporte = $"{request.correlativo}-{DateTime.Now.Year}",
                    fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                });

                _uow.Commit();
            }
            catch (Exception e)
            {
                _uow.Rollback();
                xHelper.AbortWithInternalError();
            }

            return request.correlativo + "-" + DateTime.Now.Year;
        }

        public string GenerarReporteDocumentosIngresados(ReporteDocumentosIngresadosRequest request)
        {
            try
            {
                _uow.BeginTransaction();

                request = _documentoProceso.EjecutarGeneraReporteDocumentosIngresados(request);

                request.documentos.ToList().ForEach(x =>
                {
                    _uow.p_DOCUMENTO_DIGITALIZADO_Crud(
                        x.id_documento.Value,
                        x.id_anexo.Value,
                        request.user,
                        request.ip,
                        1,
                        request.id_reporte);
                });

                var usuario_envio = _context.Query<Modelo.vw_dat_trabajador>().FirstOrDefault(x => x.CODIGO_TRABAJADOR == request.codigo_trabajador_entrega);
                var usuario_recibido = _context.Query<Modelo.vw_dat_trabajador>().FirstOrDefault(x => x.CODIGO_TRABAJADOR == request.codigo_trabajador_recibido);
                var dependencia_recibido = _context.Query<Modelo.vw_dat_dependencia>().FirstOrDefault(x => x.CODIGO_DEPENDENCIA == request.codigo_dependencia_recibido);

                var emailRequest = new EmailRequest
                {
                    //to = $"{usuario_recibido.EMAIL}@produce.gob.pe",
                    to = "jrodriguez@produce.gob.pe;mgarciach@produce.gob.pe",
                    isBodyHtml = true,
                    subject = "STD - Nuevo reporte generado"
                };

                var sr = _emailSender.Send("NotificacionReporteDocumentosIngresados", emailRequest, new
                {
                    usuario_envio = $"{usuario_envio.NOMBRES_TRABAJADOR} {usuario_envio.APELLIDOS_TRABAJADOR}",
                    usuario_recibido = $"{usuario_recibido.NOMBRES_TRABAJADOR} {usuario_recibido.APELLIDOS_TRABAJADOR}",
                    dependencia_recibido = $"{dependencia_recibido.DEPENDENCIA}",
                    cantidad = request.documentos.Count(),
                    numero_reporte = $"{request.correlativo}-{DateTime.Now.Year}",
                    fecha = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
                });

                _uow.Commit();
            }
            catch (Exception e)
            {
                _uow.Rollback();
                xHelper.AbortWithInternalError();
            }

            return request.correlativo + "-" + DateTime.Now.Year;
        }

        public void LevantarObservaciones(DocumentoRequest request)
        {
            if (request.id_documento == null || request.id_documento == 0)
                xHelper.AbortWithInvalidRequest();

            try
            {
                var documento = _context.Query<Modelo.documento>().Include(x => x.copias)
                 .FirstOrDefault(x => x.ID_DOCUMENTO == request.id_documento);

                if (documento == null)
                    throw new ResourceNotFoundException();

                documento.ID_ESTADO_DOCUMENTO = ESTADO_DOCUMENTO.REGISTRADO;

                _context.Update(documento);

                _context.Query<Modelo.observaciones_requisitos_tramite>()
                    .Where(x => x.ID_DOCUMENTO == documento.ID_DOCUMENTO && x.ESTADO == ESTADO_OBSERVACION_REQUISITO.POR_SUBSANAR)
                    .ToList().ForEach(x =>
                    {
                        x.ESTADO = ESTADO_OBSERVACION_REQUISITO.SUBSANADO;
                        _context.Update(x);
                    });

                _uow.Save();
                _uow.Commit();
            }
            catch (Exception e)
            {
                _uow.Rollback();
                xHelper.AbortWithInternalError();
            }

        }

        public void Reactivar(DocumentoRequest request)
        {

            var errors = _documentoValidacion.ValidarReactivarDocumento(request);
            if (errors.Any())
                xHelper.AbortWithValidationErrors(errors);

            try
            {
                _uow.BeginTransaction();
                _documentoProceso.EjecutarReactivar(request);
                _uow.Commit();
            }
            catch (ResourceNotFoundException e)
            {
                _uow.Rollback();
                xHelper.AbortWithResourceNotFound();
            }
            catch (Exception e)
            {
                _uow.Rollback();
                xHelper.AbortWithInternalError();
            }
        }
        public void RevertirDocumentoReporteEscaneado(DocumentoEscaneadoRequest request)
        {

            if (request.id_documento == null || request.id_anexo == null)
                xHelper.AbortWithInvalidRequest();

            try
            {
                _uow.p_DOCUMENTO_ESTADO_Crud(request.id_documento.Value, request.id_anexo.Value, request.username, request.ip_address, 0, 0);
            }
            catch (Exception e)
            {
                _uow.Rollback();
                xHelper.AbortWithInternalError();
            }
        }

        public void RevertirDocumentoReporteIngresado(DocumentoIngresadoRequest request)
        {

            if (request.id_documento == null || request.id_anexo == null)
                xHelper.AbortWithInvalidRequest();

            try
            {
                _uow.p_DOCUMENTO_DIGITALIZADO_Crud(request.id_documento.Value, request.id_anexo.Value, request.username, request.ip_address, 0, 0);
            }
            catch (Exception e)
            {
                _uow.Rollback();
                xHelper.AbortWithInternalError();
            }
        }

        #endregion Public Methods        
    }
}
