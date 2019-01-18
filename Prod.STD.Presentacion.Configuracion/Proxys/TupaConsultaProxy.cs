using Prod.STD.Entidades;
using Release.Helper.Pagination;
using Release.Helper.Proxy;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Prod.STD.Presentacion.Configuracion.Proxys
{
    public class TupaConsultaProxy : BaseProxy
    {
        private readonly string _url;

        public TupaConsultaProxy(AppConfig appConfig)
        {            
            _url = string.Format("{0}TupaConsulta/", appConfig.Urls.URL_CERCAP_Core_API);

        }

        public PagedResponse<TupaResponse> ListByCodigoTributo(TupaFilterRequest filtro)
        {
            return this.InvokeWebApi<PagedResponse<TupaResponse>>(HttpMethod.Get, _url + "ListByCodigoTributo", this.GetJsonParameters(filtro));
        }
    }
}
