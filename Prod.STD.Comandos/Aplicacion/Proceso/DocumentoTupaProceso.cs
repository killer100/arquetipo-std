using Prod.STD.Datos;
using Prod.STD.Entidades.Documento;
using Prod.STD.Enumerados;
using Release.Helper;
using Release.Helper.Data.ICore;
using System;
using System.Globalization;
using Modelo = Prod.STD.Datos.Modelo;
using System.Linq;
using Prod.STD.Entidades.Comun;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Prod.STD.Comandos.Aplicacion.Proceso
{
    public class DocumentoTupaProceso : AccionGenerica<DocumentoRequest>
    {
        private IContext _context;
        private IUnitOfWork _uow;
        public DocumentoTupaProceso(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _context = _uow.Context;
        }

        protected override StatusResponse Registrar(DocumentoRequest request)
        {
            var sr = new StatusResponse { Value = 0 };

            Modelo.documento documento = null;

            int estado_documento = ESTADO_DOCUMENTO.REGISTRADO;

            if (!CumpleTotalRequisitos(request.requisitos))
            {
                estado_documento = ESTADO_DOCUMENTO.OBSERVADO;
            }

            var tupa = GetTupa(request.id_tup);

            documento = new Modelo.documento
            {
                ASUNTO = tupa.descripcion_format,
                ID_ESTADO_DOCUMENTO = estado_documento,
                ID_TIPO_DOCUMENTO = TIPO_DOCUMENTO.TUPA,
                ID_TUP = request.id_tup,
                ID_PERSONA = request.id_persona,
                ID_CLASE_DOCUMENTO_INTERNO = request.id_clase_documento_interno,
                FOLIOS = request.folios,
                referencia = request.referencia,
                INDICATIVO_OFICIO = request.indicativo_oficio,
                OBSERVACIONES = request.observaciones,
                NUM_TRAM_DOCUMENTARIO = request.num_tram_documentario,
                AUDITMOD = DateTime.Now,
                FECHA_RECEPCION = DateTime.Now.ToString("MMM dd yyyy hh:mmtt", CultureInfo.CreateSpecificCulture("en-EN")),
                USUARIO = request.username
            };

            documento.movimiento_documento.Add(new Modelo.movimiento_documento
            {
                AUDIT_MOD = DateTime.Now,
                ID_DEPENDENCIA_ORIGEN = (int)DEPENDENCIA_PRODUCE.OGDA,
                ID_DEPENDENCIA_DESTINO = tupa.codigo_dependencia.Value,
                ID_OFICIO = null,
                enviado = 1,
                derivado = 0,
                finalizado = 0
            });

            _context.Add(documento);
            _uow.Save();
            request.requisitos.Where(x => x.estado_observacion == false).ToList().ForEach(req =>
            {
                AddObservacionRequisito(documento.ID_DOCUMENTO, req);
            });

            //============================================================================
            // INSERTANDO EN TABLA DOCUMENTO_CONT
            //============================================================================
            
            _uow.InsertarDocumentoCont(documento.ID_DOCUMENTO);

            sr.Value = documento;
            return sr;
        }

        protected override StatusResponse Modificar(DocumentoRequest request)
        {
            var sr = new StatusResponse { Value = 0 };

            var documento = _context.Query<Modelo.documento>().Include(x => x.movimiento_documento)
                .FirstOrDefault(x => x.ID_DOCUMENTO == request.id_documento);

            var documento_cont = _context.Query<Modelo.documento_cont>().FirstOrDefault(x => x.ID_DOCUMENTO == request.id_documento);

            var tupa = GetTupa(request.id_tup);

            int estado_documento = ESTADO_DOCUMENTO.REGISTRADO;

            if (!CumpleTotalRequisitos(request.requisitos))
            {
                estado_documento = ESTADO_DOCUMENTO.OBSERVADO;
            }

            documento.ID_ESTADO_DOCUMENTO = estado_documento;
            documento.ID_TIPO_DOCUMENTO = TIPO_DOCUMENTO.TUPA;
            documento.ID_PERSONA = request.id_persona;
            documento.ID_CLASE_DOCUMENTO_INTERNO = request.id_clase_documento_interno;
            documento.FOLIOS = request.folios;
            documento.referencia = request.referencia;
            documento.INDICATIVO_OFICIO = request.indicativo_oficio;
            documento.OBSERVACIONES = request.observaciones;
            _context.Update(documento);
            _uow.Save();
            //documento.AUDITMOD = DateTime.Now;
            //documento.USUARIO = request.username;

            if (documento.ID_TUP != request.id_tup)
            {
                documento.ID_TUP = request.id_tup;
                documento.ASUNTO = tupa.descripcion_format;
                documento.Fecha_Max_Plazo = null;
                documento.movimiento_documento.Where(x => x.ID_OFICIO == null).OrderBy(x => x.AUDIT_MOD).ToList().ForEach(mov =>
                {
                    mov.ID_DEPENDENCIA_DESTINO = tupa.codigo_dependencia.Value;
                });

                EliminarRequisitos(documento.ID_DOCUMENTO);

                request.requisitos.Where(x => x.estado_observacion == false).ToList().ForEach(req =>
                {
                    AddObservacionRequisito(documento.ID_DOCUMENTO, req);
                });

            }
            else
            {
                ActualizarRequisitos(documento.ID_DOCUMENTO, request.requisitos);
            }

            //============================================================================
            // ACTUALIZANDO TABLA DOCUMENTO_CONT
            //============================================================================

            if (documento_cont == null)
            {
                _uow.InsertarDocumentoCont(documento.ID_DOCUMENTO);
            }

            sr.Value = documento;
            return sr;
        }

        #region HELPERS
        /// <summary>
        /// Se excluye los registros con id_requisito == 0 ya que sirven solo para registrar observaciones generales.
        /// </summary>
        /// <param name="id_documento"></param>
        /// <param name="requisito"></param>
        /// <returns></returns>
        private void AddObservacionRequisito(int id_documento, RequisitoTupaRequest requisito)
        {
            var newRequisito = new Modelo.observaciones_requisitos_tramite
            {
                ID = _context.Query<Modelo.observaciones_requisitos_tramite>().Max(x => x.ID) + 1,
                ID_DOCUMENTO = id_documento,
                ID_REQUISITO_TUPA = requisito.id_requisito,
                OBSERVACIONES = requisito.observaciones,
                ESTADO = ESTADO_OBSERVACION_REQUISITO.POR_SUBSANAR
            };
            _context.Add(newRequisito);
            _uow.Save();
        }


        private void EliminarRequisitos(int id_documento)
        {
            _context.Query<Modelo.observaciones_requisitos_tramite>()
                 .Where(x => x.ID_DOCUMENTO == id_documento && x.ESTADO != ESTADO_OBSERVACION_REQUISITO.ELIMINADO).ToList().ForEach(obs =>
                 {
                     obs.ESTADO = ESTADO_OBSERVACION_REQUISITO.ELIMINADO;
                     _context.Update(obs);
                 });
            _uow.Save();
        }

        private void ActualizarRequisitos(int id_documento, List<RequisitoTupaRequest> requisitos)
        {
            var observaciones = _context.Query<Modelo.observaciones_requisitos_tramite>()
                 .Where(x => x.ID_DOCUMENTO == id_documento && x.ESTADO != ESTADO_OBSERVACION_REQUISITO.ELIMINADO).ToList();

            var observaciones_ids = observaciones.Select(x => x.ID_REQUISITO_TUPA).ToList();

            requisitos.Where(x => observaciones_ids.Contains(x.id_requisito)).ToList().ForEach(req =>
            {
                var observacion = observaciones.Where(obs => obs.ID_REQUISITO_TUPA == req.id_requisito).FirstOrDefault();

                if (observacion != null)
                {
                    observacion.ESTADO = req.estado_observacion ? ESTADO_OBSERVACION_REQUISITO.SUBSANADO : ESTADO_OBSERVACION_REQUISITO.POR_SUBSANAR;
                    _context.Update(observacion);
                    _uow.Save();
                }
            });

            requisitos.Where(x => !observaciones_ids.Contains(x.id_requisito)).ToList().ForEach(req =>
            {
                if (req.estado_observacion == false)
                {
                    AddObservacionRequisito(id_documento, req);
                }
            });
        }

        private bool CumpleTotalRequisitos(ICollection<RequisitoTupaRequest> requisitos)
        {
            var requisitosTotal = requisitos.Where(x => x.id_requisito != 0).Count();
            var requisitosCumplidos = requisitos.Where(
                x => x.estado_observacion == true && x.id_requisito != 0
            ).Count();
            return requisitosTotal == requisitosCumplidos;
        }

        private TupaResponse GetTupa(int? id)
        {
            return _context.Query<Modelo.vw_dat_tupa>().Where(x => x.ID_TUPA == id).Select(x => new TupaResponse
            {
                codigo_dependencia = x.CODIGO_DEPENDENCIA,
                descripcion = x.DESCRIPCION
            }).FirstOrDefault();
        }
        #endregion
    }
}
