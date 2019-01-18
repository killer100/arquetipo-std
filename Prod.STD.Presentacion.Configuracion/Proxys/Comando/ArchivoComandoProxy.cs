using Prod.STD.Entidades.Archivo;
using Prod.STD.Entidades.Comando;
using Release.Helper.Proxy;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Prod.STD.Presentacion.Configuracion.Proxys
{
    public class ArchivoComandoProxy : BaseProxy
    {
        private readonly string _url;
        public ArchivoComandoProxy(AppConfig appConfig)
        {
            _url = $"{appConfig.Urls.URL_STD_Core_API}/archivoComando";
        }
        public CommandResponse<ArchivoResponse> UploadFileTemp(ArchivoRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.CallWebApi<CommandResponse<ArchivoResponse>>(HttpMethod.Post, $"{_url}/upload/temp-archivo", body);
        }
    }
}
