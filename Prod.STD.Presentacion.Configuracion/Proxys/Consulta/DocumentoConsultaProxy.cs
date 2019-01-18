using Prod.STD.Entidades;
using Prod.STD.Entidades.Comando;
using Prod.STD.Entidades.Comun;
using Prod.STD.Entidades.DetalleHojaRuta;
using Prod.STD.Entidades.Documento;
using Prod.STD.Entidades.DocumentoEscaneado;
using Prod.STD.Entidades.DocumentoIngresado;
using Prod.STD.Entidades.FlujoDocumentario;
using Release.Helper;
using Release.Helper.Pagination;
using Release.Helper.Proxy;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Prod.STD.Presentacion.Configuracion.Proxys
{
    public class DocumentoConsultaProxy : BaseProxy
    {
        private readonly string _url;

        public DocumentoConsultaProxy(AppConfig appConfig)
        {
            _url = $"{appConfig.Urls.URL_STD_Core_API}/documentoConsulta";
        }

        //============================================================================
        // GET
        //============================================================================

        public CommandResponse<DocumentoResponse> GetDocumentoComun(int id, string related = null)
        {
            var queryString = "";
            if (!string.IsNullOrEmpty(related))
            {
                queryString += $"?related={related}";
            }
            return this.CallWebApi<CommandResponse<DocumentoResponse>>(HttpMethod.Get, $"{_url}/comun/{id}{queryString}", null);
        }

        //============================================================================
        // SEARCH
        //============================================================================

        public PagedResponse<DocumentoResponse> SearchMesaPartes(DocumentoFilter filters, string related = null)
        {
            var queryString = "";
            if (!string.IsNullOrEmpty(related))
            {
                queryString += $"?related={related}";
            }
            var body = this.GetJsonParameters(filters);
            return this.CallWebApi<PagedResponse<DocumentoResponse>>(HttpMethod.Get, $"{_url}/search/mesa-partes{queryString}", body);
        }
        #region Gestión Interna
        public PagedResponse<DocumentoResponse> SearchGestionInterna(DocumentoFilter filters, string related = null)
        {
            var queryString = "";
            if (!string.IsNullOrEmpty(related))
            {
                queryString += $"?related={related}";
            }
            var body = this.GetJsonParameters(filters);
            return this.CallWebApi<PagedResponse<DocumentoResponse>>(HttpMethod.Get, $"{_url}/search/gestion-interna{queryString}", body);
        }
        public CommandResponse<DocumentoResponse> GetDocFromHojaTramite(DocumentoFilter filters)
        {
            var body = this.GetJsonParameters(filters);
            return this.CallWebApi<CommandResponse<DocumentoResponse>>(HttpMethod.Get, $"{_url}/search/gestion-interna/GetDocFromHojaTramite", body);
        }
        #endregion        

        public PagedResponse<DocumentoIngresadoResponse> SearchMesaPartesDocumentosIngresados(DocumentoIngresadoFilter filters)
        {
            var body = this.GetJsonParameters(filters);
            return this.InvokeWebApi<PagedResponse<DocumentoIngresadoResponse>>(HttpMethod.Get, $"{_url}/search/mesa-partes/ingresados", body);
        }

        public PagedResponse<DocumentoEscaneadoResponse> SearchMesaPartesDocumentosEscaneados(DocumentoEscaneadoFilter filters)
        {
            var body = this.GetJsonParameters(filters);
            return this.InvokeWebApi<PagedResponse<DocumentoEscaneadoResponse>>(HttpMethod.Get, $"{_url}/search/mesa-partes/escaneados", body);
        }

        public PagedResponse<ReporteDocumentoIngresadoResponse> SearchReportesDocumentosIngresados(PagedRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.InvokeWebApi<PagedResponse<ReporteDocumentoIngresadoResponse>>(HttpMethod.Get, $"{_url}/search/mesa-partes/reportes-documentos-ingresados", body);
        }

        public PagedResponse<ReporteDocumentoEscaneadoResponse> SearchReportesDocumentosEscaneados(PagedRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.InvokeWebApi<PagedResponse<ReporteDocumentoEscaneadoResponse>>(HttpMethod.Get, $"{_url}/search/mesa-partes/reportes-documentos-escaneados", body);
        }

        //============================================================================
        // QUERIES
        //============================================================================

        public CommandResponse<ICollection<DependenciaResponse>> GetOficinasPendientes(int id_documento)
        {
            return this.CallWebApi<CommandResponse<ICollection<DependenciaResponse>>>(HttpMethod.Get, $"{_url}/query/{id_documento}/oficinas-pendientes", null);
        }

        public CommandResponse<ICollection<DependenciaResponse>> GetOficinasFinalizadas(int id_documento)
        {
            return this.CallWebApi<CommandResponse<ICollection<DependenciaResponse>>>(HttpMethod.Get, $"{_url}/query/{id_documento}/oficinas-finalizadas", null);
        }

        public CheckResponse CheckMesaPartesPuedeModificar(int id_documento)
        {
            return this.CallWebApi<CheckResponse>(HttpMethod.Get, $"{_url}/query/{id_documento}/check-mesa-partes-puede-modificar", null);
        }

        public CheckResponse CheckMesaPartesPuedeAnular(int id_documento)
        {
            return this.CallWebApi<CheckResponse>(HttpMethod.Get, $"{_url}/query/{id_documento}/check-mesa-partes-puede-anular", null);
        }

        public CheckResponse CheckMesaPartesPuedeAgregarCopia(int id_documento)
        {
            return this.CallWebApi<CheckResponse>(HttpMethod.Get, $"{_url}/query/{id_documento}/check-mesa-partes-puede-agregar-copia", null);
        }

        public CheckResponse CheckMesaPartesPuedeReactivar(int id_documento)
        {
            return this.CallWebApi<CheckResponse>(HttpMethod.Get, $"{_url}/query/{id_documento}/check-mesa-partes-puede-reactivar", null);
        }

        public CheckResponse CheckMesaPartesPuedeAdjuntar(int id_documento)
        {
            return this.CallWebApi<CheckResponse>(HttpMethod.Get, $"{_url}/query/{id_documento}/check-mesa-partes-puede-adjuntar", null);
        }

        public CheckResponse CheckMesaPartesPuedeLevantarObservaciones(int id_documento)
        {
            return this.CallWebApi<CheckResponse>(HttpMethod.Get, $"{_url}/query/{id_documento}/check-mesa-partes-puede-levantar-observaciones", null);
        }

        public CommandResponse<DetalleHojaRutaResponse> HojaRutaDocumentoInterno(int id_documento)
        {
            return this.CallWebApi<CommandResponse<DetalleHojaRutaResponse>>(HttpMethod.Get, $"{_url}/query/{id_documento}/hoja-ruta-interna", null);
        }

        public CommandResponse<DetalleHojaRutaResponse> HojaRutaDocumentoExterno(int id_documento)
        {
            return this.CallWebApi<CommandResponse<DetalleHojaRutaResponse>>(HttpMethod.Get, $"{_url}/query/{id_documento}/hoja-ruta-externa", null);
        }
        

            public CommandResponse<FlujoDocumentarioResponse> FlujoDocumentoInterno(int id_documento)
        {
            return this.CallWebApi<CommandResponse<FlujoDocumentarioResponse>>(HttpMethod.Get, $"{_url}/query/{id_documento}/flujo-documento-interno", null);
        }

        public CommandResponse<FlujoDocumentarioResponse> FlujoDocumentoExterno(int id_documento)
        {
            return this.CallWebApi<CommandResponse<FlujoDocumentarioResponse>>(HttpMethod.Get, $"{_url}/query/{id_documento}/flujo-documento-externo", null);
        }

    }

}
