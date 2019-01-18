using Prod.STD.Entidades.Comando;
using Prod.STD.Entidades.Documento;
using Prod.STD.Entidades.DocumentoEscaneado;
using Prod.STD.Entidades.DocumentoIngresado;
using Release.Helper.Proxy;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Prod.STD.Presentacion.Configuracion.Proxys
{
    public class DocumentoComandoProxy : BaseProxy
    {
        private readonly string _url;

        public DocumentoComandoProxy(AppConfig appConfig)
        {
            _url = $"{appConfig.Urls.URL_STD_Core_API}/documentoComando";
        }

        public CommandResponse Anular(DocumentoRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.CallWebApi<CommandResponse>(HttpMethod.Post, $"{_url}/actions/anular", body);
        }

        public CommandResponse AgregarCopias(DocumentoRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.CallWebApi<CommandResponse>(HttpMethod.Post, $"{_url}/actions/agregar-copias", body);
        }

        public CommandResponse LevantarObservaciones(DocumentoRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.CallWebApi<CommandResponse>(HttpMethod.Post, $"{_url}/actions/levantar-observaciones", body);
        }

        public CommandResponse ReactivarRegistro(DocumentoRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.CallWebApi<CommandResponse>(HttpMethod.Post, $"{_url}/actions/reactivar", body);
        }

        public CommandResponse GenerarReporteIngresados(ReporteDocumentosIngresadosRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.CallWebApi<CommandResponse>(HttpMethod.Post, $"{_url}/actions/generar-reporte-ingresados", body);
        }

        public CommandResponse RevertirDocumentoReporteIngresado(DocumentoIngresadoRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.CallWebApi<CommandResponse>(HttpMethod.Post, $"{_url}/actions/revertir-documento-reporte-ingresado", body);
        }

        public CommandResponse GenerarReporteEscaneados(ReporteDocumentosEscaneadosRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.CallWebApi<CommandResponse>(HttpMethod.Post, $"{_url}/actions/generar-reporte-escaneados", body);
        }

        public CommandResponse RevertirDocumentoReporteEscaneado(DocumentoEscaneadoRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.CallWebApi<CommandResponse>(HttpMethod.Post, $"{_url}/actions/revertir-documento-reporte-escaneado", body);
        }

    }
}
