using Microsoft.AspNetCore.Mvc;
using Prod.STD.Entidades.DocumentoEscaneado;
using Prod.STD.Presentacion.Configuracion;
using Prod.STD.Presentacion.Configuracion.Proxys;
using Prod.STD.Presentacion.MVC.Controllers;
using Release.Helper.Pagination;
using System;
using System.Net;

namespace Prod.STD.Presentacion.MVC.Areas.MesaPartes.Controllers
{
    [Route("api/mesa-partes/documentos-escaneados")]
    public class DocumentosEscaneadosController : CustomBaseController
    {
        private readonly DocumentoConsultaProxy _documentoConsulta;
        private readonly DocumentoExternoComandoProxy _documentoExternoComando;
        private readonly DocumentoTupaComandoProxy _documentoTupaComando;
        private readonly DocumentoComandoProxy _documentoComando;
        private readonly AppConfig _appConfig;

        public DocumentosEscaneadosController(DocumentoConsultaProxy documentoConsulta,
            DocumentoExternoComandoProxy documentoExternoComando,
            DocumentoTupaComandoProxy documentoTupaComando,
            DocumentoComandoProxy documentoComando,
            AnexoComandoProxy anexo,
            AppConfig appConfig)
        {
            _documentoConsulta = documentoConsulta;
            _documentoExternoComando = documentoExternoComando;
            _documentoTupaComando = documentoTupaComando;
            _documentoComando = documentoComando;
            _appConfig = appConfig;
        }

        [HttpPost]
        [Route("documentos")]
        public IActionResult Page([FromBody]DocumentoEscaneadoFilter filters)
        {
            var results = _documentoConsulta.SearchMesaPartesDocumentosEscaneados(filters);
            return _Response(results);
        }

        [HttpPost]
        [Route("generar-reporte")]
        public IActionResult GenerarReporte([FromBody]ReporteDocumentosEscaneadosRequest request)
        {
            if (request != null)
            {
                var usuario = GetUser();
                request.username = usuario.UserName;
                request.ip_address = HttpContext.Connection.RemoteIpAddress.ToString();
                request.codigo_trabajador_entrega = Convert.ToInt32(usuario.IdUsuario);
                request.codigo_dependencia_entrega = usuario.IdDependencia;
            }
            var result = _documentoComando.GenerarReporteEscaneados(request);
            return _Response(result);
        }

        [HttpPost]
        [Route("revertir-documento-reporte")]
        public IActionResult RevertirDocumentoReporte([FromBody]DocumentoEscaneadoRequest request)
        {
            if (request != null)
            {
                var usuario = GetUser();
                request.username = usuario.UserName;
                request.ip_address = HttpContext.Connection.RemoteIpAddress.ToString();
            }
            var result = _documentoComando.RevertirDocumentoReporteEscaneado(request);
            return _Response(result);
        }

        [HttpPost]
        [Route("page-reportes")]
        public IActionResult ReportesDocumentosEscaneados([FromBody]PagedRequest request)
        {
            var result = _documentoConsulta.SearchReportesDocumentosEscaneados(request);
            return _Response(result);
        }



        [HttpGet]
        [Route("ver-documentos-reporte")]
        public IActionResult VerDocumentosReporte([FromQuery]int numero_reporte = 0)
        {
            WebClient WebClient = new WebClient();

            var filepath = $"{_appConfig.ReportConfig.UrlReportServer}?{_appConfig.ReportConfig.ReportFolder}REPORTE_DOCUMENTOS_ESCANEADOS&rs:Format=EXCEL&numero_reporte={numero_reporte}";

            NetworkCredential nwc = new NetworkCredential($"{_appConfig.ReportConfig.User}", $"{_appConfig.ReportConfig.Password}");

            WebClient.Credentials = nwc;
            byte[] filedata = WebClient.DownloadData(filepath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = "REPORTE_DOCUMENTOS.xls",
                Inline = false
            };

            Response.Headers.Add("Content-Disposition", cd.ToString());
            return File(filedata, "application/vnd.ms-excel");

        }
    }
}