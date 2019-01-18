using Prod.STD.Entidades;
using Release.Helper.Pagination;
using Release.Helper.Proxy;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Prod.STD.Presentacion.Configuracion.Proxys
{
    public class RegistroComandoProxy : BaseProxy
    {
        private readonly string _url;

        public RegistroComandoProxy(AppConfig appConfig)
        {            
            _url = string.Format("{0}RegistroComando/", appConfig.Urls.URL_CERCAP_Core_API);

        }
        
        public RegistroResponse DetailsRegistro(RegistroFilterRequest filtro)
        {
            return this.InvokeWebApi<RegistroResponse>(HttpMethod.Post, _url + "DetailsRegistro", this.GetJsonParameters(filtro));
        }        
        
    }
}
