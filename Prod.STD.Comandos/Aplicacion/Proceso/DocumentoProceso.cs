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
using Prod.STD.Enumerados;
using Prod.STD.Entidades.DocumentoIngresado;
using Prod.STD.Entidades.DocumentoEscaneado;

namespace Prod.STD.Comandos.Aplicacion.Proceso
{
    public class DocumentoProceso : AccionGenerica<DocumentoRequest>
    {
        private IContext _context;
        private IUnitOfWork _uow;
        public DocumentoProceso(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _context = _uow.Context;
        }

        protected override StatusResponse Registrar(DocumentoRequest request)
        {
            throw new NotImplementedException();
        }

        protected override StatusResponse Anular(DocumentoRequest request)
        {
            var sr = new StatusResponse { Value = 0 };

            var documento = _context.Query<Modelo.documento>().Where(x => x.ID_DOCUMENTO == request.id_documento).FirstOrDefault();

            if (documento == null)
                throw new ResourceNotFoundException();

            //======================================================================================================
            // SE ASIGNAN LAS PROPIEDADES
            //======================================================================================================

            documento.ID_ESTADO_DOCUMENTO = ESTADO_DOCUMENTO.ELIMINADO;

            documento.OBSERVACIONES = request.observaciones;

            _context.Update(documento);

            //======================================================================================================
            // SE BORRAN LOS MOVIMIENTOS DEL DOCUMENTO
            //======================================================================================================

            _context.DeleteWhere<Modelo.movimiento_documento>(x => x.ID_DOCUMENTO == request.id_documento);

            _uow.Save();

            return sr;
        }
        public void EjecutarReactivar(DocumentoRequest request)
        {
            var documento = _context.Query<Modelo.documento>().Where(x => x.ID_DOCUMENTO == request.id_documento).FirstOrDefault();

            if (documento == null)
                throw new ResourceNotFoundException();

            //======================================================================================================
            // SE ASIGNAN LAS PROPIEDADES
            //======================================================================================================

            documento.ID_ESTADO_DOCUMENTO = ESTADO_DOCUMENTO.REGISTRADO;

            documento.OBSERVACIONES = request.observaciones;

            //======================================================================================================
            // SE REACTIVAN LOS MOVIMIENTOS HACIA LA DEPENDENCIA DESTINO
            //======================================================================================================

            _context.Query<Modelo.movimiento_documento>().Where(x =>
                x.ID_DOCUMENTO == request.id_documento &&
                x.ID_DEPENDENCIA_DESTINO == request.oficina_derivada &&
                x.derivado == 0 && x.finalizado == 1).ToList().ForEach(mov =>
                {
                    mov.finalizado = 0;
                    _context.Update(mov);
                });

            _uow.Save();
        }

        public ReporteDocumentosIngresadosRequest EjecutarGeneraReporteDocumentosIngresados(ReporteDocumentosIngresadosRequest request)
        {
            var correlativo = _context.Query<Modelo.dat_reporte_digitalizado>().Select(x => x.numero_reporte).DefaultIfEmpty(0).Max() + 1;

            var reporte = new Modelo.dat_reporte_digitalizado
            {
                estado = 1,
                numero_reporte = correlativo,
                user_registro = request.user,
                ip_user_registro = request.ip,
                fecha_registro = DateTime.Now,
                codigo_trabajador_entregado = request.codigo_trabajador_entrega,
                coddep_entregado = request.codigo_dependencia_entrega,
                codigo_trabajador_recibido = request.codigo_trabajador_recibido,
                coddep_recibido = request.codigo_dependencia_recibido,
                observacion = request.observaciones,
                user_audit = request.user,
                ip_audit = request.ip,
                fecha_recibido = DateTime.Now,
                fecha_audit = DateTime.Now,
                fecha_filtro_ini = null,
                fecha_filtro_fin = null
            };

            _context.Add(reporte);
            _uow.Save();

            request.id_reporte = reporte.id_reporte;
            request.correlativo = correlativo.Value;

            return request;
        }

        public ReporteDocumentosEscaneadosRequest EjecutarGeneraReporteDocumentosEscaneados(ReporteDocumentosEscaneadosRequest request)
        {
            var correlativo = _context.Query<Modelo.dat_reporte_documentos>().Select(x => x.numero_reporte).DefaultIfEmpty(0).Max() + 1;

            var reporte = new Modelo.dat_reporte_documentos
            {
                estado = 1,
                numero_reporte = correlativo,
                user_registro = request.username,
                ip_user_registro = request.ip_address,
                fecha_registro = DateTime.Now,
                user_audit = request.username,
                ip_audit = request.ip_address,
                fecha_recibido = DateTime.Now,
                fecha_audit = DateTime.Now,
                fecha_filtro_ini = null,
                fecha_filtro_fin = null
            };

            _context.Add(reporte);
            _uow.Save();

            request.id_reporte = reporte.id_reporte;
            request.correlativo = correlativo.Value;

            return request;
        }

    }
}
