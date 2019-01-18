using Microsoft.EntityFrameworkCore;
using Prod.STD.Datos;
using Prod.STD.Entidades.Documento;
using Prod.STD.Enumerados;
using Release.Helper;
using Release.Helper.Data.ICore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Modelo = Prod.STD.Datos.Modelo;
using System.Linq;

namespace Prod.STD.Comandos.Aplicacion.Proceso
{
    public class DocumentoExternoProceso : AccionGenerica<DocumentoRequest>
    {
        private IContext _context;
        private IUnitOfWork _uow;
        public DocumentoExternoProceso(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _context = _uow.Context;
        }

        protected override StatusResponse Registrar(DocumentoRequest request)
        {
            var sr = new StatusResponse { Value = 0 };

            Modelo.documento documento = null;

            //============================================================================
            // CREANDO NUEVO DOCUMENTO
            //============================================================================

            documento = new Modelo.documento
            {
                ID_ESTADO_DOCUMENTO = ESTADO_DOCUMENTO.REGISTRADO,
                ID_TIPO_DOCUMENTO = TIPO_DOCUMENTO.EXTERNO,
                ID_PERSONA = request.id_persona,
                ASUNTO = request.asunto,
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

            //============================================================================
            // CREANDO NUEVO MOVIMIENTO
            //============================================================================

            documento.movimiento_documento.Add(new Modelo.movimiento_documento
            {
                AUDIT_MOD = DateTime.Now,
                ID_DEPENDENCIA_ORIGEN = (int)DEPENDENCIA_PRODUCE.OGDA,
                ID_DEPENDENCIA_DESTINO = request.oficina_derivada.Value,
                ID_OFICIO = null,
                enviado = 1,
                derivado = 0,
                finalizado = 0
            });

            //============================================================================
            // REGISTRANDO COPIAS
            //============================================================================

            if (request.copias != null)
            {
                documento.copias = new List<Modelo.dat_documento_copia>();
                request.copias.Where(x => x.coddep != null).ToList().ForEach(x =>
                {
                    documento.copias.Add(new Modelo.dat_documento_copia
                    {
                        LEIDO = 0,
                        CODDEP = x.coddep.Value,
                        ESTADO = ESTADO_DOCUMENTO_COPIA.ACTIVO,
                        AUDITCREA = DateTime.Now
                    });
                });
            }

            _context.Add(documento);
            _uow.Save();

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

            var documento = _context.Query<Modelo.documento>().Include(x => x.movimiento_documento).Include(x => x.copias)
                .FirstOrDefault(x => x.ID_DOCUMENTO == request.id_documento);

            var documento_cont = _context.Query<Modelo.documento_cont>().FirstOrDefault(x => x.ID_DOCUMENTO == request.id_documento);

            //============================================================================
            // COPIANDO DATOS NUEVOS A LA ENTIDAD
            //============================================================================

            documento.ID_ESTADO_DOCUMENTO = ESTADO_DOCUMENTO.REGISTRADO;
            documento.ID_TIPO_DOCUMENTO = TIPO_DOCUMENTO.EXTERNO;
            documento.ID_PERSONA = request.id_persona;
            documento.ASUNTO = request.asunto;
            documento.ID_CLASE_DOCUMENTO_INTERNO = request.id_clase_documento_interno;
            documento.FOLIOS = request.folios;
            documento.referencia = request.referencia;
            documento.INDICATIVO_OFICIO = request.indicativo_oficio;
            documento.OBSERVACIONES = request.observaciones;
            //documento.AUDITMOD = DateTime.Now;
            //documento.USUARIO = request.username;

            if (request.copias != null)
            {
                var coddeps = documento.copias == null ?
                    new List<int>() :
                    documento.copias.Where(x => x.ESTADO == ESTADO_DOCUMENTO_COPIA.ACTIVO).Select(x => x.CODDEP);

                var intersect = request.copias.Where(x => x.coddep != null).Select(x => x.coddep.Value).Intersect(coddeps);

                documento.copias.Where(x => !intersect.Contains(x.CODDEP)).ToList().ForEach(x =>
                {
                    x.ESTADO = ESTADO_DOCUMENTO_COPIA.ELIMINADO;
                    _context.Update(x);
                });

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
            }

            _context.Update(documento);
            _uow.Save();

            //============================================================================
            // SI HUBO CAMBIO DE DESTINO ACTUALIZAR EN MOVIMIENTO DOCUMENTO
            //============================================================================
            var mov = documento.movimiento_documento.FirstOrDefault();
            if (mov.ID_DEPENDENCIA_DESTINO != request.oficina_derivada.Value)
            {
                mov.ID_DEPENDENCIA_DESTINO = request.oficina_derivada.Value;
                _uow.Save();
            }

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

            sr.Value = documento;
            return sr;
        }
    }
}
