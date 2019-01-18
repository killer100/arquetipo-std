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
    public class DocumentoInternoComandoController : BaseController
    {
        private readonly IDocumentoInternoAplicacion _documentoInternoAplicacion;
        public DocumentoInternoComandoController(IDocumentoInternoAplicacion documentoInternoAplicacion)
        {
            _documentoInternoAplicacion = documentoInternoAplicacion;
        }
        [HttpPost]
        [Route("")]
        public CommandResponse<DocumentoResponse> Save([FromBody]DocumentoRequest request)
        {
            return this.TryCatch(() =>
            {
                request.year = DateTime.Now.Year;
                var documento = _documentoInternoAplicacion.Save(request);
                return _Response(documento.num_tram_documentario, data: documento);
            });
        }
    }
}
