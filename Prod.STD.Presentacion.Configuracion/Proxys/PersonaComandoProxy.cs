using Prod.STD.Entidades;
using Release.Helper;
using Release.Helper.Proxy;
using System.Net.Http;

namespace Prod.STD.Presentacion.Configuracion.Proxys
{
    public class PersonaComandoProxy : BaseProxy
    {
        private readonly string _url;

        public PersonaComandoProxy(AppConfig appConfig)
        {
            _url = string.Format("{0}PersonaComando/", appConfig.Urls.URL_CERCAP_Core_API);

        }
        public StatusResponse Eliminar(PersonaFilter request)
        {
            return this.InvokeWebApi<StatusResponse>(HttpMethod.Post, _url + "Eliminar", this.GetJsonParameters(request));
        }
        public StatusResponse Modificar(PersonaRequest request)
        {
            return this.InvokeWebApi<StatusResponse>(HttpMethod.Post, _url + "Modificar", this.GetJsonParameters(request));
        }
      
        public StatusResponse Registrar(PersonaRequest request)
        {
            return this.InvokeWebApi<StatusResponse>(HttpMethod.Post, _url + "Registrar", this.GetJsonParameters(request));
        }
    }

}
