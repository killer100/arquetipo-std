using Prod.STD.Datos;
using Prod.STD.Entidades.Anexo;
using Release.Helper;
using Release.Helper.Data.ICore;
using System;
using System.Collections.Generic;
using System.Text;
using Modelo = Prod.STD.Datos.Modelo;
using System.Linq;
using Prod.STD.Enumerados;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Prod.STD.Core;

namespace Prod.STD.Comandos.Aplicacion.Proceso
{
    public class AnexoProceso : AccionGenerica<AnexoRequest>
    {
        private IContext _context;
        private IUnitOfWork _uow;
        public AnexoProceso(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _context = _uow.Context;
        }

        protected override StatusResponse Registrar(AnexoRequest request)
        {
            var sr = new StatusResponse { Value = 0 };

            //============================================================================
            // OBTENCION DE CORRELATIVO Y DATOS DEL DOCUMENTO
            //============================================================================
            var documento = _context.Query<Modelo.documento>().Where(x => x.ID_DOCUMENTO == request.id_documento).FirstOrDefault();
            var documento_cont = _context.Query<Modelo.documento_cont>().FirstOrDefault(x => x.ID_DOCUMENTO == request.id_documento);
            var correlativo = _context.Query<Modelo.anexo>().Where(x => x.ID_DOCUMENTO == request.id_documento && x.ESTADO_ADJUNTO != ESTADO_ADJUNTO.ANULADO).Select(x => x.CORRELATIVO).DefaultIfEmpty(0).Max() + 1;

            //============================================================================
            // OBTENCION DE DEPENDENCIA DESTINO: ULTIMA DEPENDENCIA PENDIENTE
            //============================================================================
            var dependencia_pendiente = _context.Query<Modelo.movimiento_documento>().Include(x => x.dependencia_destino)
                .Where(x => x.ID_DOCUMENTO == request.id_documento && x.derivado == 0 && x.finalizado == 0)
                .OrderByDescending(x => x.AUDIT_MOD).Select(x => x.dependencia_destino).FirstOrDefault();

            //============================================================================
            // OBTENCION DE PERSONA DESTINO
            //============================================================================
            var trabajador_destino = _context.Query<Modelo.vw_dat_trabajador>()
                .Where(x => x.CODIGO_DEPENDENCIA == dependencia_pendiente.CODIGO_DEPENDENCIA && x.ESTADO == "ACTIVO" && x.DIRECTOR == 1).FirstOrDefault();

            //============================================================================
            // INSERCION EN LA TABLA ANEXO
            //============================================================================
            var anexo = new Modelo.anexo
            {
                ID_ANEXO = _context.Query<Modelo.anexo>().Max(x => x.ID_ANEXO) + 1,
                ID_DOCUMENTO = request.id_documento.Value,
                ID_TIPO_ANEXO = request.id_tipo_anexo.Value,
                NUM_DOCUMENTO_ANEXO = $"{documento.NUM_TRAM_DOCUMENTARIO}-{correlativo}",
                ID_PERSONA_DESTINO = trabajador_destino.CODIGO_TRABAJADOR,
                FOLIOS = request.folios.Value,
                CONTENIDO = request.contenido,
                OBSERVACIONES = string.IsNullOrEmpty(request.observaciones) ? "" : request.observaciones,
                USUARIO = request.usuario,
                AUDIT_MOD = DateTime.Now,
                coddep = request.coddep,
                ID_PERSONA = request.id_persona,
                CORRELATIVO = correlativo,
                ESTADO_ADJUNTO = ESTADO_ADJUNTO.ACTIVO
            };

            _context.Add(anexo);
            _uow.Save();

            //======================================================================================================
            // INSERCION EN LA TABLA DOCUMENTO
            //======================================================================================================
            var documento_adjunto = new Modelo.documento
            {
                INDICATIVO_OFICIO = "ADJUNTO",
                ID_ESTADO_DOCUMENTO = ESTADO_DOCUMENTO.REGISTRADO,
                ID_TIPO_DOCUMENTO = TIPO_DOCUMENTO.INTERNO,
                FECHA_RECEPCION = " ",
                ID_CLASE_DOCUMENTO_INTERNO = CLASE_DOCUMENTO_INTERNO.SIN_DOCUMENTO,
                ASUNTO = "SE ENVÍA ADJUNTO " + anexo.NUM_DOCUMENTO_ANEXO,
                OBSERVACIONES = "SIN OBSERVACIONES",
                AUDITMOD = DateTime.Now,
                USUARIO = request.usuario,
                coddep = request.coddep
            };

            _context.Add(documento_adjunto);
            _uow.Save();

            //======================================================================================================
            // ACTUALIZACION DEL ID EN LA TABLA ANEXO
            //======================================================================================================
            anexo.ID_DOCUMENTO_ADJUNTO = documento_adjunto.ID_DOCUMENTO;
            _context.Update(anexo);

            //======================================================================================================
            // ACTUALIZACION DEL MOVIMIENTO DOCUMENTO REFERENTE A LA DEPENDENCIA DESTINO
            //======================================================================================================
            _context.Query<Modelo.movimiento_documento>()
                .Where(x =>
                x.ID_DOCUMENTO == request.id_documento &&
                x.ID_DEPENDENCIA_DESTINO == dependencia_pendiente.CODIGO_DEPENDENCIA).ToList().ForEach(mov =>
                {
                    mov.derivado = 1;
                    mov.finalizado = 0;
                    mov.AUDIT_REC = DateTime.Now;
                    _context.Update(mov);
                });

            //======================================================================================================
            // INSERCION DE NUEVO MOVIMIENTO PARA EL DOCUMENTO ADJUNTO
            //======================================================================================================
            var nuevo_movimiento = new Modelo.movimiento_documento
            {
                enviado = 1,
                ID_DOCUMENTO = request.id_documento.Value,
                ID_DEPENDENCIA_ORIGEN = DEPENDENCIA_PRODUCE.OGDA,
                ID_DEPENDENCIA_DESTINO = dependencia_pendiente.CODIGO_DEPENDENCIA,
                ID_OFICIO = documento_adjunto.ID_DOCUMENTO,
                AUDIT_MOD = DateTime.Now
            };

            _context.Add(nuevo_movimiento);
            _uow.Save();

            //=====================================================================================================
            // ACTUALIZANDO TABLA DOCUMENTO_CONT
            //=====================================================================================================

            if (documento_cont != null)
            {
                documento_cont.CANT_ADJUNTOS = _context.Query<Modelo.anexo>().Where(x => x.ID_DOCUMENTO == documento.ID_DOCUMENTO && x.ESTADO_ADJUNTO == ESTADO_ADJUNTO.ACTIVO).Count();
                _context.Update(documento_cont);
                _uow.Save();
            }
            else
            {
                _uow.InsertarDocumentoCont(documento.ID_DOCUMENTO);
            }

            sr.Value = anexo;
            return sr;
        }

        protected override StatusResponse Modificar(AnexoRequest request)
        {
            var sr = new StatusResponse { Value = 0 };

            var anexo = _context.Query<Modelo.anexo>().Where(x => x.ID_ANEXO == request.id_anexo).FirstOrDefault();

            if (anexo == null)
                throw new ResourceNotFoundException();

            //======================================================================================================
            // ASIGNACION DE VALORES A MODIFICAR
            //======================================================================================================
            anexo.ID_PERSONA = request.id_persona;
            anexo.ID_TIPO_ANEXO = request.id_tipo_anexo.Value;
            anexo.FOLIOS = request.folios.Value;
            anexo.CONTENIDO = request.contenido;
            anexo.OBSERVACIONES = request.observaciones;
            anexo.modificado = "MODIFICADO POR " + request.usuario.ToUpper() + " EL " + DateTime.Now.ToString("MMM dd yyyy hh:mmtt", CultureInfo.CreateSpecificCulture("en-EN")).ToUpper();

            _context.Update(anexo);

            _uow.Save();

            return sr;
        }

        protected override StatusResponse Anular(AnexoRequest request)
        {
            var anexo = _context.Query<Modelo.anexo>().Include(x => x.persona_destino).Where(x => x.ID_ANEXO == request.id_anexo).FirstOrDefault();

            if (anexo == null)
                throw new ResourceNotFoundException();

            var documento_cont = _context.Query<Modelo.documento_cont>().FirstOrDefault(x => x.ID_DOCUMENTO == anexo.ID_DOCUMENTO);

            anexo.MOTIVO_ANULACION = request.motivo_anulacion;
            anexo.ESTADO_ADJUNTO = ESTADO_ADJUNTO.ANULADO;
            _context.Update(anexo);

            //======================================================================================================
            // NUEVA LOGICA DE ADJUNTOS
            //======================================================================================================
            if (anexo.ID_DOCUMENTO_ADJUNTO != null)
            {
                var documento_adjunto = _context.Query<Modelo.documento>().Where(x => x.ID_DOCUMENTO == anexo.ID_DOCUMENTO_ADJUNTO).FirstOrDefault();
                documento_adjunto.ID_ESTADO_DOCUMENTO = ESTADO_DOCUMENTO.ELIMINADO;
                documento_adjunto.OBSERVACIONES = request.motivo_anulacion;
                _context.Update(documento_adjunto);

                _context.DeleteWhere<Modelo.movimiento_documento>(x => x.ID_OFICIO == anexo.ID_DOCUMENTO_ADJUNTO);
            }
            //======================================================================================================
            // ANTIGUA LOGICA DE ADJUNTOS
            //======================================================================================================
            else
            {
                var documento_adjunto = _context.Query<Modelo.documento>().Where(x => x.INDICATIVO_OFICIO.Trim() == "ADJUNTO" && x.ASUNTO.Trim().Contains(anexo.NUM_DOCUMENTO_ANEXO)).FirstOrDefault();
                if (documento_adjunto != null)
                {
                    documento_adjunto.ID_ESTADO_DOCUMENTO = ESTADO_DOCUMENTO.ELIMINADO;
                    documento_adjunto.OBSERVACIONES = request.motivo_anulacion;
                    _context.Update(documento_adjunto);
                    _context.DeleteWhere<Modelo.movimiento_documento>(x => x.ID_OFICIO == documento_adjunto.ID_DOCUMENTO);
                }
            }

            _uow.Save();

            var movimiento_previo = _context.Query<Modelo.movimiento_documento>().Where(
                x => x.ID_DEPENDENCIA_DESTINO == anexo.persona_destino.CODIGO_DEPENDENCIA &&
                x.derivado == 1).OrderByDescending(x => x.AUDIT_MOD).FirstOrDefault();

            if (movimiento_previo != null)
            {
                movimiento_previo.derivado = 0;
                movimiento_previo.finalizado = 0;
                _context.Update(movimiento_previo);
                _uow.Save();
            }

            //=====================================================================================================
            // ACTUALIZANDO TABLA DOCUMENTO_CONT
            //=====================================================================================================

            if (documento_cont != null)
            {
                documento_cont.CANT_ADJUNTOS = _context.Query<Modelo.anexo>().Where(x => x.ID_DOCUMENTO == anexo.ID_DOCUMENTO && x.ESTADO_ADJUNTO == ESTADO_ADJUNTO.ACTIVO).Count();
                _context.Update(documento_cont);
                _uow.Save();
            }
            else
            {
                _uow.InsertarDocumentoCont(anexo.ID_DOCUMENTO);
            }

            return null;
        }
    }
}