using Prod.STD.Entidades;
using Release.Helper;
using Release.Helper.Pagination;
using Release.Helper.Proxy;
using System.Net.Http;

namespace Prod.STD.Presentacion.Configuracion.Proxys
{
    public class PersonaConsultaProxy : BaseProxy
    {
        private readonly string _url;

        public PersonaConsultaProxy(AppConfig appConfig)
        {
            _url = string.Format("{0}PersonaConsulta/", appConfig.Urls.URL_CERCAP_Core_API);

        }
        public PagedResponse<PersonaResponse> Personas(PersonaFilter filtro)
        {
            return this.InvokeWebApi<PagedResponse<PersonaResponse>>(HttpMethod.Get, _url + "Personas", this.GetJsonParameters(filtro));
        }
    }

}
