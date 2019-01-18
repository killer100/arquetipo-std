using Microsoft.AspNetCore.Mvc;
using Prod.STD.Comandos.Aplicacion.Interface;
using Prod.STD.Core.Controllers.Base;
using Prod.STD.Entidades.Anexo;
using Prod.STD.Entidades.Comando;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Controllers.Controllers.Comandos
{
    [Route("[controller]")]
    public class AnexoComandoController : BaseController
    {

        private readonly IAnexoAplicacion _anexoAplicacion;

        public AnexoComandoController(IAnexoAplicacion anexoAplicacion)
        {
            _anexoAplicacion = anexoAplicacion;
        }

        [HttpPost]
        [Route("")]
        public CommandResponse<AnexoResponse> SaveAnexo([FromBody]AnexoRequest request)
        {
            return this.TryCatch(() =>
            {
                var anexo = _anexoAplicacion.SaveAnexo(request);
                return _Response(anexo.num_documento_anexo, data: anexo);
            });
        }

        [HttpGet]
        [Route("nuevo-numero")]
        public CommandResponse GetNuevoNumeroAnexo([FromQuery]int id_documento)
        {
            return this.TryCatch(() =>
            {
                var numero = _anexoAplicacion.GetNuevoNumero(id_documento);
                return _Response(numero);
            });
        }

        [HttpPut]
        [Route("{id_anexo}")]
        public CommandResponse UpdateAnexo([FromRoute]int id_anexo, [FromBody]AnexoRequest request)
        {
            return this.TryCatch(() =>
            {
                _anexoAplicacion.UpdateAnexo(id_anexo, request);
                return _Response(msg: "Registro actualizado");
            });
        }

        #region ACCIONES
        [HttpPost]
        [Route("actions/anular")]
        public CommandResponse AnularAnexo([FromBody]AnexoRequest request)
        {
            return this.TryCatch(() =>
            {
                _anexoAplicacion.AnularAnexo(request);
                return _Response(msg: "Documento anulado");
            });
        }
        #endregion
    }
}
