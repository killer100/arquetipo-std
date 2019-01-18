using Prod.STD.Comandos.Aplicacion.Interface;
using Prod.STD.Comandos.Aplicacion.Validacion;
using Prod.STD.Core;
using Prod.STD.Datos;
using Prod.STD.Entidades.Documento;
using System;
using Modelo = Prod.STD.Datos.Modelo;
using System.Linq;
using System.Text;
using Prod.STD.Comandos.Aplicacion.Proceso;
using Release.Helper;

namespace Prod.STD.Comandos.Aplicacion
{
    public class DocumentoInternoAplicacion : IDocumentoInternoAplicacion
    {

        private readonly DocumentoValidacion _documentoValidacion;
        private readonly ContadorProceso _contadorProceso;
        private IUnitOfWork _uow;
        private readonly DocumentoInternoProceso _documentoInternoProceso;

        public DocumentoInternoAplicacion(DocumentoValidacion documentoValidacion, 
                                          IUnitOfWork uow, 
                                          DocumentoInternoProceso documentoInternoProceso,
                                          ContadorProceso contadorProceso
            )
        {
            _documentoValidacion = documentoValidacion;
            _uow = uow;
            _documentoInternoProceso = documentoInternoProceso;
            _contadorProceso = contadorProceso;
        }
        public DocumentoResponse Save(DocumentoRequest request)
        {
            var errors = _documentoValidacion.ValidarNuevoDocumentoInterno(request);
            if (errors.Any())
                xHelper.AbortWithValidationErrors(errors);

            Modelo.documento documento = null;
            try
            {
                _uow.BeginTransaction();

                request.indicativo_oficio = _contadorProceso.EjecutarRegistrarInterno(
                    request.year,
                    request.id_clase_documento_interno,
                    request.username);
                StatusResponse resultDoc = _documentoInternoProceso.EjecutaRegistrar(request);
                documento = (Modelo.documento)resultDoc.Value;

                _uow.Commit();
            }
            catch (Exception e)
            {
                _uow.Rollback();
                xHelper.AbortWithInternalError();
            }
            return new DocumentoResponse
            {
                indicativo_oficio = documento.INDICATIVO_OFICIO,
                id_documento = documento.ID_DOCUMENTO
            };
        }
    }
}
