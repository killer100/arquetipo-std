using Microsoft.AspNetCore.Mvc;
using Doc = Prod.STD.Entidades.Documento;
using Prod.STD.Documento.Applicacion.Interfaces;
using Release.Helper.Pagination;
using System.Collections.Generic;

namespace Prod.STD.Documento.Controllers
{
    [Route("[controller]")]
    public class DocumentoConsultaController : Controller
    {

        private readonly IDocumentoAplicacion _documentosAplicacion;

        public DocumentoConsultaController(IDocumentoAplicacion documentosAplicacion)
        {
            _documentosAplicacion = documentosAplicacion;
        }

        [HttpGet]
        [Route("BusquedaPaginada")]
        public PagedResponse<Doc.Archivo> BusquedaPaginada([FromBody]Doc.ArchivoFiltro filtro)
        {
            return _documentosAplicacion.BusquedaPaginada(filtro);
        }
        [HttpGet]
        [Route("Archivo")]
        public Doc.Archivo Archivo([FromBody]Doc.ArchivoFiltro filtro)
        {
            return _documentosAplicacion.Archivo(filtro);
        }
    }
}
