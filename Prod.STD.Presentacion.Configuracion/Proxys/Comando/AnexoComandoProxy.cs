using Prod.STD.Entidades.Anexo;
using Prod.STD.Entidades.Comando;
using Release.Helper.Proxy;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Prod.STD.Presentacion.Configuracion.Proxys
{
    public class AnexoComandoProxy : BaseProxy
    {
        private readonly string _url;

        public AnexoComandoProxy(AppConfig appConfig)
        {
            _url = $"{appConfig.Urls.URL_STD_Core_API}/anexoComando";
        }

        public CommandResponse<AnexoResponse> SaveAnexo(AnexoRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.CallWebApi<CommandResponse<AnexoResponse>>(HttpMethod.Post, $"{_url}/", body);
        }

        public CommandResponse UpdateAnexo(int id_anexo, AnexoRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.CallWebApi<CommandResponse>(HttpMethod.Put, $"{_url}/{id_anexo}", body);
        }

        public CommandResponse NuevoNumero(int id_documento)
        {
            return this.CallWebApi<CommandResponse>(HttpMethod.Get, $"{_url}/nuevo-numero?id_documento={id_documento}", null);
        }

        public CommandResponse AnularAnexo(AnexoRequest request)
        {
            var body = this.GetJsonParameters(request);
            return this.CallWebApi<CommandResponse>(HttpMethod.Post, $"{_url}/actions/anular", body);
        }

    }
}
