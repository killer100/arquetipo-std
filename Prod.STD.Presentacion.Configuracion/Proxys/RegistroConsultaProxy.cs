using Prod.STD.Entidades;
using Release.Helper.Pagination;
using Release.Helper.Proxy;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Prod.STD.Presentacion.Configuracion.Proxys
{
    public class RegistroConsultaProxy : BaseProxy
    {
        private readonly string _url;

        public RegistroConsultaProxy(AppConfig appConfig)
        {            
            _url = string.Format("{0}RegistroConsulta/", appConfig.Urls.URL_CERCAP_Core_API);

        }
        
        public RegistroResponse getDetailsRegistro(RegistroFilterRequest filtro)
        {
            return this.InvokeWebApi<RegistroResponse>(HttpMethod.Get, _url + "getDetailsRegistro", this.GetJsonParameters(filtro));
        }
        
        public PagedResponse<RegistroResponse> getRegistroList(RegistroFilterRequest filtro)
        {
            return this.InvokeWebApi<PagedResponse<RegistroResponse>>(HttpMethod.Get, _url + "getRegistroList", this.GetJsonParameters(filtro));
        }
    }
}
