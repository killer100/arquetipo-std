using AutoMapper;
using Prod.STD.Comandos.Aplicacion.Interface;
using Prod.STD.Comandos.Aplicacion.Proceso;
using Prod.STD.Comandos.Aplicacion.Validacion;
using Prod.STD.Datos;
using Prod.STD.Entidades.Documento;
using Release.Helper;
using Release.Helper.Data.ICore;
using System;
using System.Collections.Generic;
using System.Text;
using Modelo = Prod.STD.Datos.Modelo;
using System.Linq;
using Prod.STD.Core;
using Prod.STD.Core.Resources;

namespace Prod.STD.Comandos.Aplicacion
{
    public class DocumentoTupaAplicacion : IDocumentoTupaAplicacion
    {
        private IContext _context;
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly DocumentoValidacion _documentoValidacion;
        private readonly ContadorProceso _contadorProceso;
        private readonly DocumentoTupaProceso _documentoTupaProceso;
        private readonly MovimientoDocumentoProceso _movimientoDocumentoProceso;

        public DocumentoTupaAplicacion(IUnitOfWork unitOfWork,
            IMapper mapper,
            DocumentoValidacion documentoValidacion,
            ContadorProceso contadorProceso,
            DocumentoTupaProceso documentoTupaProceso,
            MovimientoDocumentoProceso movimientoDocumentoProceso)
        {
            _uow = unitOfWork;
            _context = _uow.Context;
            _documentoValidacion = documentoValidacion;
            _contadorProceso = contadorProceso;
            _documentoTupaProceso = documentoTupaProceso;
            _movimientoDocumentoProceso = movimientoDocumentoProceso;
            _mapper = mapper;
        }

        public DocumentoResponse Save(DocumentoRequest request)
        {
            var errors = _documentoValidacion.ValidarNuevoDocumentoTupa(request);
            if (errors.Any())
                xHelper.AbortWithValidationErrors(errors);

            Modelo.documento documento = null;

            try
            {
                _uow.BeginTransaction();
                request.num_tram_documentario = _contadorProceso.EjecutarRegistrarExterno(
                    request.year,
                    request.username,
                    request.hostname);
                StatusResponse resultDoc = _documentoTupaProceso.EjecutaRegistrar(request);
                documento = (Modelo.documento)resultDoc.Value;
                documento.Fecha_Max_Plazo = _uow.EstablecerFechaMaxPlazo(documento.ID_DOCUMENTO);
                documento.clave = _uow.FN_GENERA_CLAVE_DOCUMENTO_TRAMITE(documento.NUM_TRAM_DOCUMENTARIO);
                _context.Update(documento);
                _uow.Save();
                _uow.Commit();
            }
            catch (Exception e)
            {
                _uow.Rollback();
                xHelper.AbortWithInternalError();
            }

            return new DocumentoResponse
            {
                num_tram_documentario = documento.NUM_TRAM_DOCUMENTARIO,
                id_documento = documento.ID_DOCUMENTO
            };
        }

        public void Update(int id_documento, DocumentoRequest request)
        {
            var errors = _documentoValidacion.ValidarActualizarDocumentoTupa(request);
            if (errors.Any())
                xHelper.AbortWithValidationErrors(errors);

            try
            {
                _uow.BeginTransaction();
                request.id_documento = id_documento;
                StatusResponse resultDoc = _documentoTupaProceso.EjecutaModificar(request);
                var documento = (Modelo.documento)resultDoc.Value;
                if (string.IsNullOrEmpty(documento.Fecha_Max_Plazo))
                {
                    documento.Fecha_Max_Plazo = _uow.EstablecerFechaMaxPlazo(documento.ID_DOCUMENTO);
                    _uow.Save();
                }
                _uow.Commit();
            }
            catch (Exception e)
            {
                _uow.Rollback();
                xHelper.AbortWithInternalError();
            }
        }
    }
}
