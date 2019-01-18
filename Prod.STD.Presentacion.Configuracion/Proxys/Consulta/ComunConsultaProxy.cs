using Prod.STD.Entidades.Comun;
using Prod.STD.Entidades.Comun.Filters;
using Prod.STD.Entidades.Enumerable;
using Release.Helper;
using Release.Helper.Proxy;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Prod.STD.Presentacion.Configuracion.Proxys
{
    public class ComunConsultaProxy : BaseProxy
    {
        private readonly string _url;

        public ComunConsultaProxy(AppConfig appConfig)
        {
            _url = $"{appConfig.Urls.URL_STD_Core_API}/comunconsulta";
        }

        public ICollection<DependenciaResponse> GetDependencias(DependenciaFilter filters)
        {
            var body = this.GetJsonParameters(filters);
            return this.CallWebApi<ICollection<DependenciaResponse>>(HttpMethod.Get, $"{_url}/dependencia", body);
        }

        public ICollection<ClaseDocumentoResponse> GetClasesDocumento(ClaseDocumentoFilter filters)
        {
            var body = this.GetJsonParameters(filters);
            return this.CallWebApi<ICollection<ClaseDocumentoResponse>>(HttpMethod.Get, $"{_url}/clase-documento", body);
        }
        public ICollection<TipoTratamientoResponse> GetTiposTratamiento()
        {
            return this.CallWebApi<ICollection<TipoTratamientoResponse>>(HttpMethod.Get, $"{_url}/tipos-tratamiento", null);
        }
        public ICollection<TipoResolucionResponse> GetTiposResolucion()
        {
            return this.CallWebApi<ICollection<TipoResolucionResponse>>(HttpMethod.Get, $"{_url}/tipo-resolucion", null);
        }

        public ICollection<ClaseTupaResponse> GetClasesTupa()
        {
            return this.CallWebApi<ICollection<ClaseTupaResponse>>(HttpMethod.Get, $"{_url}/clase-tupa", null);
        }

        public ICollection<TupaResponse> GetTupas(TupaFilter filters)
        {
            var body = this.GetJsonParameters(filters);
            return this.CallWebApi<ICollection<TupaResponse>>(HttpMethod.Get, $"{_url}/tupa", body);
        }

        public ICollection<PersonaResponse> GetPersonas(PersonaFilter filters)
        {
            var body = this.GetJsonParameters(filters);
            return this.CallWebApi<ICollection<PersonaResponse>>(HttpMethod.Get, $"{_url}/persona", body);
        }

        public ICollection<RequisitoTupaResponse> GetRequisitosTupa(int id_tupa)
        {
            return this.CallWebApi<ICollection<RequisitoTupaResponse>>(HttpMethod.Get, $"{_url}/requisito-tupa?id_tupa={id_tupa}", null);
        }

        public ICollection<TipoAnexoResponse> GetTiposAnexo()
        {
            return this.CallWebApi<ICollection<TipoAnexoResponse>>(HttpMethod.Get, $"{_url}/tipo-anexo", null);
        }

        public ICollection<TrabajadorResponse> GetTrabajadores(TrabajadorFilter filters)
        {
            var body = this.GetJsonParameters(filters);
            return this.CallWebApi<ICollection<TrabajadorResponse>>(HttpMethod.Get, $"{_url}/trabajador", body);
        }
    }

}
