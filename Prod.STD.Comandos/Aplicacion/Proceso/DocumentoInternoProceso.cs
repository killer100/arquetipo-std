using Prod.STD.Entidades.Documento;
using Release.Helper;
using Modelo = Prod.STD.Datos.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using Release.Helper.Data.ICore;
using Prod.STD.Datos;
using Prod.STD.Enumerados;
using System.Globalization;
using System.Linq;

namespace Prod.STD.Comandos.Aplicacion.Proceso
{
    public class DocumentoInternoProceso : AccionGenerica<DocumentoRequest>
    {
        private IContext _context;
        private IUnitOfWork _uow;
        public DocumentoInternoProceso(IUnitOfWork unitOfWork)
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
                ID_TIPO_DOCUMENTO = TIPO_DOCUMENTO.INTERNO,
                ID_CLASE_DOCUMENTO_INTERNO = request.id_clase_documento_interno,
                ASUNTO = request.asunto,
                FECHA_RECEPCION = DateTime.Now.ToString("MMM dd yyyy hh:mmtt", CultureInfo.CreateSpecificCulture("en-EN")),
                FOLIOS = request.folios,                
                INDICATIVO_OFICIO = request.indicativo_oficio,
                OBSERVACIONES = request.observaciones,                
                AUDITMOD = DateTime.Now,               
                coddep = request.codigo_dependencia,
                USUARIO = request.username
            };
            //============================================================================
            // REGISTRANDO DEPENDENCIAS DESTINOS
            //============================================================================
            //documento.documento_depdestino = new List<Modelo.documento_depdestino>();
            //request.coddeps_destino.ToList().ForEach(x =>
            //{
            //    documento.documento_depdestino.Add(new Modelo.documento_depdestino
            //    {
            //        CODDEP_DESTINO = x.codigo_dependencia,
            //        FLAG = true
            //    });
            //});
            //============================================================================
            // REGISTRANDO LAS ACCIONES
            //============================================================================
            documento.doc_tipo_documento = new List<Modelo.doc_tipo_tratamiento>();
            request.acciones.ForEach(x =>
            {
                documento.doc_tipo_documento.Add(new Modelo.doc_tipo_tratamiento
                {
                    id_tipo_tratamiento = x.id_tipo_tratamiento,
                    dependencia = null,
                    id = 0
                });
            });
            //============================================================================
            // REGISTRANDO LAS REFERENCIAS
            //============================================================================
           //documento.documento_referencia = new List<Modelo.documento_referencia>();
           //request.referencias.ForEach(x =>
           //{
           //    documento.documento_referencia.Add(new Modelo.documento_referencia
           //    {
           //        TIPO_HOJA_TRAMITE = x.tipo_hoja_tramite,
           //        NUMERO_HOJA_TRAMITE = x.numero_hoja_tramite,
           //        ID_HOJA_TRAMITE = x.id_hoja_tramite,
           //        FLAG = true
           //    });
           //});
            //============================================================================
            // REGISTRANDO LOS ADJUNTOS (ARCHIVOS)
            //============================================================================
          //documento.documento_adjunto = new List<Modelo.documento_adjunto>();
          //request.adjuntos.ForEach(x =>
          //{
          //    documento.documento_adjunto.Add(new Modelo.documento_adjunto
          //    {
          //        NOMBRE_ADJUNTO = x.nombre_adjunto,
          //        MIMETYPE = x.mimetype,
          //        SIZE= x.size,
          //        CODIGO = x.codigo,
          //        FLAG = true
          //    });
          //});
            _context.Add(documento);
            _uow.Save();

            sr.Value = documento;
            return sr;
        }

    }
}
