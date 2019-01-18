using Microsoft.AspNetCore.Mvc;
using Prod.STD.Consultas.Aplicacion.Interface;
using Prod.STD.Core.Controllers.Base;
using Prod.STD.Entidades.Anexo;
using Prod.STD.Entidades.Comando;
using Prod.STD.Entidades.Comun;
using Release.Helper.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Consultas.Controllers
{
    [Route("[controller]")]
    public class AnexoConsultaController : BaseController
    {
        private readonly IAnexoAplicacion _anexoAplicacion;
        public AnexoConsultaController(IAnexoAplicacion anexoAplicacion)
        {
            _anexoAplicacion = anexoAplicacion;
        }

        /// <summary>
        /// Obtiene un documento adjunto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public CommandResponse<AnexoResponse> Anexo([FromRoute]int id)
        {
            return this.TryCatch(() =>
            {
                var anexo = _anexoAplicacion.GetAnexo(id);
                return _Response(data: anexo);
            });
        }

        /// <summary>
        /// Obtiene listado de anexos
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("search")]
        public PagedResponse<AnexoResponse> SearchAnexos([FromBody]AnexoFilter filters)
        {
            return _anexoAplicacion.SearchAnexos(filters);
        }

        [HttpGet]
        [Route("query/{id_anexo}/check-can-update-remove")]
        public CommandResponse<CheckResponse> CanUpdateOrRemove([FromRoute]int id_anexo)
        {
            return this.TryCatch(() =>
            {
                var check = _anexoAplicacion.CheckCanUpdateOrRemove(id_anexo);
                var response = new CheckResponse { check = check };
                return _Response(data: response);
            });
        }
    }
}
