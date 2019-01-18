using Microsoft.AspNetCore.Mvc;
using Prod.STD.Comandos.Aplicacion.Interface;
using Prod.STD.Core.Controllers.Base;
using Prod.STD.Entidades.Comando;
using Prod.STD.Entidades.Documento;
using Prod.STD.Entidades.DocumentoEscaneado;
using Prod.STD.Entidades.DocumentoIngresado;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Comandos.Controllers
{
    [Route("[controller]")]
    public class DocumentoComandoController : BaseController
    {

        private readonly IDocumentoAplicacion _documentoAplicacion;

        public DocumentoComandoController(IDocumentoAplicacion documentoAplicacion)
        {
            _documentoAplicacion = documentoAplicacion;
        }

        [HttpPost]
        [Route("actions/anular")]
        public CommandResponse Anular([FromBody]DocumentoRequest request)
        {
            return this.TryCatch(() =>
            {
                _documentoAplicacion.Anular(request);
                return _Response(msg: "Se anuló el documento");
            });
        }

        [HttpPost]
        [Route("actions/reactivar")]
        public CommandResponse Reactivar([FromBody]DocumentoRequest request)
        {
            return this.TryCatch(() =>
            {
                _documentoAplicacion.Reactivar(request);
                return _Response(msg: "Se reactivó el documento");
            });
        }

        [HttpPost]
        [Route("actions/agregar-copias")]
        public CommandResponse AgregarCopias([FromBody]DocumentoRequest request)
        {
            return this.TryCatch(() =>
            {
                _documentoAplicacion.AgregarCopias(request);
                return _Response(msg: "Se agregaron las copias");
            });
        }

        [HttpPost]
        [Route("actions/levantar-observaciones")]
        public CommandResponse LevantarObservaciones([FromBody]DocumentoRequest request)
        {
            return this.TryCatch(() =>
            {
                _documentoAplicacion.LevantarObservaciones(request);
                return _Response(msg: "Se levantaron las observaciones");
            });
        }

        [HttpPost]
        [Route("actions/generar-reporte-ingresados")]
        public CommandResponse GenerarReporteDocumentosIngresados([FromBody]ReporteDocumentosIngresadosRequest request)
        {
            return this.TryCatch(() =>
            {
                var numero_reporte = _documentoAplicacion.GenerarReporteDocumentosIngresados(request);
                return _Response(msg: "Se creó el reporte " + numero_reporte);
            });
        }

        [HttpPost]
        [Route("actions/revertir-documento-reporte-ingresado")]
        public CommandResponse RevertirDocumentoReporteIngresado([FromBody]DocumentoIngresadoRequest request)
        {
            return this.TryCatch(() =>
            {
                _documentoAplicacion.RevertirDocumentoReporteIngresado(request);
                return _Response(msg: "Se revirtió el documento");
            });
        }

        [HttpPost]
        [Route("actions/generar-reporte-escaneados")]
        public CommandResponse GenerarReporteDocumentosEscaneados([FromBody]ReporteDocumentosEscaneadosRequest request)
        {
            return this.TryCatch(() =>
            {
                var numero_reporte = _documentoAplicacion.GenerarReporteDocumentosEscaneados(request);
                return _Response(msg: "Se creó el reporte " + numero_reporte);
            });
        }

        [HttpPost]
        [Route("actions/revertir-documento-reporte-escaneado")]
        public CommandResponse RevertirDocumentoReporteEscaneado([FromBody]DocumentoEscaneadoRequest request)
        {
            return this.TryCatch(() =>
            {
                _documentoAplicacion.RevertirDocumentoReporteEscaneado(request);
                return _Response(msg: "Se revirtió el documento");
            });
        }

    }
}
