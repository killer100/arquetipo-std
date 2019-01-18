using Prod.STD.Entidades.Comando;
using Prod.STD.Entidades.Documento;
using Release.Helper.Proxy;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Prod.STD.Presentacion.Configuracion.Proxys
{
    public class DocumentoTupaComandoProxy : BaseProxy
    {
        private readonly string _url;

        public DocumentoTupaComandoProxy(AppConfig appConfig)
        {
            _url = $"{appConfig.Urls.URL_STD_Core_API}/documentoTupaComando";
        }

        public CommandResponse<DocumentoResponse> Save(DocumentoRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.CallWebApi<CommandResponse<DocumentoResponse>>(HttpMethod.Post, $"{_url}", body);
        }

        public CommandResponse Update(int id, DocumentoRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.CallWebApi<CommandResponse>(HttpMethod.Put, $"{_url}/{id}", body);
        }

    }
}
