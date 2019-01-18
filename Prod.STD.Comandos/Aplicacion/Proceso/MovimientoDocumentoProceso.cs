using Prod.STD.Datos;
using Prod.STD.Entidades.Documento;
using Prod.STD.Entidades.MovimientoDocumento;
using Release.Helper;
using Release.Helper.Data.ICore;
using System;
using Modelo = Prod.STD.Datos.Modelo;
using System.Linq;

namespace Prod.STD.Comandos.Aplicacion.Proceso
{
    public class MovimientoDocumentoProceso : AccionGenerica<MovimientoDocumentoRequest>
    {
        private IContext _context;
        private IUnitOfWork _uow;

        public MovimientoDocumentoProceso(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
            _context = _uow.Context;
        }
        protected override StatusResponse Registrar(MovimientoDocumentoRequest request)
        {
            var sr = new StatusResponse { Value = 0 };

            _context.Query<Modelo.movimiento_documento>()
                .Where(x => x.ID_DOCUMENTO == request.id_documento &&
                x.ID_DEPENDENCIA_DESTINO == request.id_dependencia_destino &&
                x.derivado == 0)
                .ToList().ForEach(mov => { mov.derivado = 1; });

            var movimiento_documento = new Modelo.movimiento_documento
            {
                ID_DOCUMENTO = request.id_documento,
                ID_OFICIO = request.id_oficio,
                ID_DEPENDENCIA_ORIGEN = request.id_dependencia_origen,
                ID_DEPENDENCIA_DESTINO = request.id_dependencia_destino,
                AUDIT_MOD = DateTime.Now,
                enviado = request.enviado,
                derivado = request.derivado,
                finalizado = request.finalizado
            };

            _context.Add(movimiento_documento);
            _uow.Save();

            return sr;
        }

    }
}
