using Prod.STD.Entidades.Comando;
using Prod.STD.Entidades.Documento;
using Release.Helper.Proxy;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Prod.STD.Presentacion.Configuracion.Proxys.Comando
{
    public class DocumentoInternoComandoProxy : BaseProxy
    {
        private readonly string _url;
        public DocumentoInternoComandoProxy(AppConfig appConfig)
        {
            _url = $"{appConfig.Urls.URL_STD_Core_API}/documentoInternoComando";
        }
        public CommandResponse<DocumentoResponse> Save(DocumentoRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.CallWebApi<CommandResponse<DocumentoResponse>>(HttpMethod.Post, $"{_url}", body);
        }
    }
}
