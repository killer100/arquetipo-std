using AutoMapper;
using Prod.STD.Comandos.Aplicacion.Interface;
using Prod.STD.Comandos.Aplicacion.Validacion;
using Prod.STD.Comandos.Aplicacion.Proceso;
using Prod.STD.Datos;
using Prod.STD.Entidades.Anexo;
using Release.Helper.Data.ICore;
using System;
using System.Collections.Generic;
using System.Text;
using Modelo = Prod.STD.Datos.Modelo;
using System.Linq;
using Prod.STD.Core;
using Release.Helper;
using Prod.STD.Core.Resources;
using Microsoft.EntityFrameworkCore;
using Prod.STD.Enumerados;

namespace Prod.STD.Comandos.Aplicacion
{
    public class AnexoAplicacion : IAnexoAplicacion
    {
        private IContext _context;
        private IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AnexoValidacion _anexoValidacion;
        private readonly AnexoProceso _anexoProceso;
        public AnexoAplicacion(IUnitOfWork unitOfWork, IMapper mapper, AnexoValidacion anexoValidacion, AnexoProceso anexoProceso)
        {
            _uow = unitOfWork;
            _context = _uow.Context;
            _mapper = mapper;
            _anexoValidacion = anexoValidacion;
            _anexoProceso = anexoProceso;
        }
        public AnexoResponse SaveAnexo(AnexoRequest request)
        {
            var errors = _anexoValidacion.ValidarNuevoAdjunto(request);

            if (errors.Any())
                xHelper.AbortWithValidationErrors(errors);

            Modelo.anexo anexo = null;
            try
            {
                _uow.BeginTransaction();

                StatusResponse result = _anexoProceso.EjecutaRegistrar(request);

                anexo = (Modelo.anexo)result.Value;

                _uow.Commit();
            }
            catch (Exception e)
            {
                _uow.Rollback();
                xHelper.AbortWithInternalError();
            }

            return new AnexoResponse
            {
                id_anexo = anexo.ID_ANEXO,
                num_documento_anexo = anexo.NUM_DOCUMENTO_ANEXO
            };
        }

        public void UpdateAnexo(int id_anexo, AnexoRequest request)
        {
            var errors = _anexoValidacion.ValidarModificaAdjunto(request);

            if (errors.Any())
                xHelper.AbortWithValidationErrors(errors);

            request.id_anexo = id_anexo;

            try
            {
                _uow.BeginTransaction();
                _anexoProceso.EjecutaModificar(request);
                _uow.Commit();
            }
            catch (Exception e)
            {
                _uow.Rollback();

                xHelper.AbortWithInternalError();
            }
        }

        public void AnularAnexo(AnexoRequest request)
        {
            if (request.id_anexo == null || request.id_anexo == 0)
                xHelper.AbortWithInvalidRequest();

            try
            {
                _uow.BeginTransaction();
                _anexoProceso.EjecutaAnular(request);
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

        public string GetNuevoNumero(int id_documento)
        {
            var documento = _context.Query<Modelo.documento>().Where(x => x.ID_DOCUMENTO == id_documento).FirstOrDefault();
            if (documento == null)
                return null;
            var correlativo = _context.Query<Modelo.anexo>().Where(x =>
                    x.ID_DOCUMENTO == id_documento &&
                    x.ESTADO_ADJUNTO != ESTADO_ADJUNTO.ANULADO)
                .Select(x => x.CORRELATIVO).DefaultIfEmpty(0).Max() + 1;
            return $"{documento.NUM_TRAM_DOCUMENTARIO}-{correlativo}";
        }

    }
}
