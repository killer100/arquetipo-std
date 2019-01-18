using Prod.STD.Entidades.Anexo;
using Prod.STD.Entidades.Comando;
using Prod.STD.Entidades.Comun;
using Release.Helper.Pagination;
using Release.Helper.Proxy;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Prod.STD.Presentacion.Configuracion.Proxys
{
    public class AnexoConsultaProxy : BaseProxy
    {
        private readonly string _url;

        public AnexoConsultaProxy(AppConfig appConfig)
        {
            _url = $"{appConfig.Urls.URL_STD_Core_API}/anexoConsulta";
        }

        public CommandResponse<AnexoResponse> GetAnexo(int id)
        {
            return this.CallWebApi<CommandResponse<AnexoResponse>>(HttpMethod.Get, $"{_url}/{id}", null);
        }

        public PagedResponse<AnexoResponse> SearchAnexos(AnexoFilter filters)
        {
            var body = this.GetJsonParameters(filters);
            return this.CallWebApi<PagedResponse<AnexoResponse>>(HttpMethod.Post, $"{_url}/search", body);
        }

        public CommandResponse<CheckResponse> CheckCanEditOrRemove(int id)
        {
            return this.CallWebApi<CommandResponse<CheckResponse>>(HttpMethod.Get, $"{_url}/query/{id}/check-can-update-remove", null);
        }
    }
}
