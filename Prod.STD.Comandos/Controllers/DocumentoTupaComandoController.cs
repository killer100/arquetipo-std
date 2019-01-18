using Microsoft.AspNetCore.Mvc;
using Prod.STD.Comandos.Aplicacion.Interface;
using Prod.STD.Core.Controllers.Base;
using Prod.STD.Entidades.Comando;
using Prod.STD.Entidades.Documento;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Comandos.Controllers
{
    [Route("[controller]")]
    public class DocumentoTupaComandoController : BaseController
    {
        private readonly IDocumentoTupaAplicacion _documentoTupaAplicacion;

        public DocumentoTupaComandoController(IDocumentoTupaAplicacion documentoTupaAplicacion)
        {
            _documentoTupaAplicacion = documentoTupaAplicacion;
        }


        [HttpPost]
        [Route("")]
        public CommandResponse<DocumentoResponse> Save([FromBody]DocumentoRequest request)
        {
            return this.TryCatch(() =>
            {
                request.year = DateTime.Now.Year;
                var documento = _documentoTupaAplicacion.Save(request);
                return _Response(documento.num_tram_documentario, data: documento);
            });
        }

        [HttpPut]
        [Route("{id}")]
        public CommandResponse Update([FromRoute]int id, [FromBody]DocumentoRequest request)
        {
            return this.TryCatch(() =>
            {
                request.year = DateTime.Now.Year;
                _documentoTupaAplicacion.Update(id, request);
                return _Response(msg: "Registro actualizado");
            });
        }

    }
}

