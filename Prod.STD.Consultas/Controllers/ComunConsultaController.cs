using Microsoft.AspNetCore.Mvc;
using Prod.STD.Consultas.Aplicacion.Interface;
using Prod.STD.Entidades;
using Prod.STD.Entidades.Comun;
using Prod.STD.Entidades.Comun.Filters;
using Prod.STD.Entidades.Enumerable;
using Release.Helper;
using System.Collections.Generic;

namespace Prod.STD.Consultas.Controllers
{
    [Route("[controller]")]
    public class ComunConsultaController : Controller
    {
        private readonly IComunAplicacion _comunAplicacion;

        public ComunConsultaController(IComunAplicacion comunAplicacion)
        {
            _comunAplicacion = comunAplicacion;
        }

        /// <summary>
        /// Obtiene el listado de dependencias de produce
        /// </summary>
        /// <param name="filters">Filtros que se pueden aplicar</param>
        /// <response code="200">Lista de dependencias</response>
        [HttpGet]
        [Route("dependencia")]
        public ICollection<DependenciaResponse> Dependencias([FromBody]DependenciaFilter filters)
        {
            return _comunAplicacion.GetDependencias(filters);
        }

        /// <summary>
        /// Obtiene el listado de clases de documento
        /// </summary>
        /// <returns>A string status</returns>
        [HttpGet]
        [Route("clase-documento")]
        public ICollection<ClaseDocumentoResponse> ClasesDocumento([FromBody]ClaseDocumentoFilter filters)
        {
            return _comunAplicacion.GetClasesDocumento(filters);
        }
        /// <summary>
        /// Obtiene el listado de tipos de tratamiento - acciones.
        /// </summary>      
        /// <returns></returns>
        [HttpGet]
        [Route("tipos-tratamiento")]
        public ICollection<TipoTratamientoResponse> TiposTratamiento()
        {
            return _comunAplicacion.GetTiposTratamiento();
        }
        /// <summary>
        /// Listado de tipos de resolución
        /// </summary>
        /// <returns>A string status</returns>
        [HttpGet]
        [Route("tipo-resolucion")]
        public ICollection<TipoResolucionResponse> TiposResolucion()
        {
            return _comunAplicacion.GetTiposResolucion();
        }

        /// <summary>
        /// Listado de clase tupas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("clase-tupa")]
        public ICollection<ClaseTupaResponse> ClasesTupa()
        {
            return _comunAplicacion.GetClasesTupa();
        }
        /// <summary>
        /// Listado de tupas, por defecto activos
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("tupa")]
        public ICollection<TupaResponse> Tupas([FromBody]TupaFilter filters)
        {
            return _comunAplicacion.GetTupas(filters);
        }

        /// <summary>
        /// Listado de personas, por defecto activos
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("persona")]
        public ICollection<PersonaResponse> Personas([FromBody]PersonaFilter filters)
        {
            return _comunAplicacion.GetPersonas(filters);
        }

        /// <summary>
        /// Listado de requisitos por tupa, por defecto activos
        /// </summary>
        /// <param name="id_tupa"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("requisito-tupa")]
        public ICollection<RequisitoTupaResponse> RequisitosTupa([FromQuery]int id_tupa)
        {
            return _comunAplicacion.GetRequisitosTupa(id_tupa);
        }

        /// <summary>
        /// Listado de tipos de anexo para los documentos adjuntos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("tipo-anexo")]
        public ICollection<TipoAnexoResponse> TipoAnexo()
        {
            return _comunAplicacion.GetTiposAnexo();
        }

        /// <summary>
        /// Obtiene la lista de trabajadores según los parámetros enviados
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("trabajador")]
        public ICollection<TrabajadorResponse> Trabajadores([FromBody]TrabajadorFilter filters)
        {
            return _comunAplicacion.GetTrabajadores(filters);
        }

    }
}
