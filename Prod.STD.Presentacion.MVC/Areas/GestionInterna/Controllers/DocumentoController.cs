using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prod.STD.Entidades.Documento;
using Prod.STD.Presentacion.Configuracion.Proxys;
using Prod.STD.Presentacion.Configuracion.Proxys.Comando;
using Prod.STD.Presentacion.MVC.Controllers;

namespace Prod.STD.Presentacion.MVC.Areas.GestionInterna.Controllers
{
    [Route("api/gestion-interna/documento")]
    public class DocumentoController : CustomBaseController
    {
        private readonly DocumentoConsultaProxy _documentoConsulta;
        private readonly DocumentoInternoComandoProxy _documentoInternoComando;

        public DocumentoController(DocumentoConsultaProxy documentoConsulta, DocumentoInternoComandoProxy documentoInternoComando)
        {
            _documentoConsulta = documentoConsulta;
            _documentoInternoComando = documentoInternoComando;
        }
        [HttpPost]
        [Route("getDocumentos")]
        public IActionResult Page([FromBody]DocumentoFilter filters)
        {
            var usuario = GetUser();
            filters.coddep = usuario.IdDependencia;
            var results = _documentoConsulta.SearchGestionInterna(filters, "estado,persona,hoja_tramite,movimientos");
            return _Response(results);
        }
        [HttpPost]
        [Route("getDocFromHojaTramite")]
        public IActionResult GetIdFromHojaTramite([FromBody]DocumentoFilter filters)
        {
            var results = _documentoConsulta.GetDocFromHojaTramite(filters);
            return _Response(results);
        }

        [HttpPost]
        [Route("documento-interno")]
        public IActionResult SaveInterno([FromBody]DocumentoRequest request)
        {
            var usuario = GetUser();
            request.username = usuario.UserName;
            request.hostname = Environment.MachineName;
            var result = _documentoInternoComando.Save(request);
            return _Response(result);
        }
    }
}