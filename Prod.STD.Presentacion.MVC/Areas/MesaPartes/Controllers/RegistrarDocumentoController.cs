using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prod.STD.Entidades.Anexo;
using Prod.STD.Entidades.Documento;
using Prod.STD.Presentacion.Configuracion.Proxys;
using Prod.STD.Presentacion.MVC.Controllers;

namespace Prod.STD.Presentacion.MVC.Areas.MesaPartes.Controllers
{
    [Route("api/mesa-partes/registrar-documento")]
    public class RegistrarDocumentoController : CustomBaseController
    {
        private readonly DocumentoConsultaProxy _documentoConsulta;
        private readonly DocumentoExternoComandoProxy _documentoExternoComando;
        private readonly DocumentoTupaComandoProxy _documentoTupaComando;
        private readonly DocumentoComandoProxy _documentoComando;
        private readonly AnexoConsultaProxy _anexoConsulta;

        public RegistrarDocumentoController(DocumentoConsultaProxy documentoConsulta,
            DocumentoExternoComandoProxy documentoExternoComando,
            DocumentoTupaComandoProxy documentoTupaComando,
            DocumentoComandoProxy documentoComando,
            AnexoConsultaProxy anexoConsulta)
        {
            _documentoConsulta = documentoConsulta;
            _documentoExternoComando = documentoExternoComando;
            _documentoTupaComando = documentoTupaComando;
            _documentoComando = documentoComando;
            _anexoConsulta = anexoConsulta;
        }

        #region CRUD DOCUMENTO

        [HttpPost]
        [Route("documentos")]
        public IActionResult Page([FromBody]DocumentoFilter filters)
        {
            var results = _documentoConsulta.SearchMesaPartes(filters, "estado,persona");
            return _Response(results);
        }

        [HttpGet]
        [Route("documento-externo/{id}")]
        public IActionResult GetDocumentoExterno([FromRoute]int id)
        {
            var result = _documentoConsulta.GetDocumentoComun(id, "persona,movimientos,copias");
            return _Response(result);
        }

        [HttpGet]
        [Route("documento-tupa/{id}")]
        public IActionResult GetDocumentoTupa([FromRoute]int id)
        {
            var result = _documentoConsulta.GetDocumentoComun(id, "persona,requisitos,tupa");
            return _Response(result);
        }

        [HttpPost]
        [Route("documento-externo")]
        public IActionResult SaveExterno([FromBody]DocumentoRequest request)
        {
            var usuario = GetUser();
            request.username = usuario.UserName;
            request.hostname = Environment.MachineName;
            var result = _documentoExternoComando.Save(request);
            return _Response(result);
        }

        [HttpPost]
        [Route("documento-tupa")]
        public IActionResult SaveTupa([FromBody]DocumentoRequest request)
        {
            var usuario = GetUser();
            request.username = usuario.UserName;
            request.hostname = Environment.MachineName;
            var result = _documentoTupaComando.Save(request);
            return _Response(result);
        }

        [HttpPut]
        [Route("documento-externo/{id}")]
        public IActionResult UpdateExterno([FromRoute]int id, [FromBody]DocumentoRequest request)
        {
            var usuario = GetUser();
            request.username = usuario.UserName;
            request.hostname = Environment.MachineName;
            var checkResponse = _documentoConsulta.CheckMesaPartesPuedeModificar(id);
            if (!checkResponse.check)
                return _Response(statuscode: 403, msg: "No se puede realizar esta acción");

            var result = _documentoExternoComando.Update(id, request);
            return _Response(result);
        }

        [HttpPut]
        [Route("documento-tupa/{id}")]
        public IActionResult UpdateTupa([FromRoute]int id, [FromBody]DocumentoRequest request)
        {
            var usuario = GetUser();
            request.username = usuario.UserName;
            request.hostname = Environment.MachineName;
            var checkResponse = _documentoConsulta.CheckMesaPartesPuedeModificar(id);
            if (!checkResponse.check)
                return _Response(statuscode: 403, msg: "No se puede realizar esta acción");

            var result = _documentoTupaComando.Update(id, request);
            return _Response(result);
        }

        #endregion

        [HttpGet]
        [Route("documento/{id}/requisitos")]
        public IActionResult GetRequisitos([FromRoute]int id)
        {
            var result = _documentoConsulta.GetDocumentoComun(id, "requisitos");
            return _Response(new { result.data.requisitos });
        }

        [HttpGet]
        [Route("documento/{id}/anexo")]
        public IActionResult GetAnexos([FromRoute]int id)
        {
            var result = _documentoConsulta.GetDocumentoComun(id, "anexos");

            result.data.anexos.ToList().ForEach(x =>
            {
                var resp = _anexoConsulta.CheckCanEditOrRemove(x.id_anexo.Value);
                x.PuedeEditarOAnular = resp.data.check;
            });

            return _Response(new { result.data.anexos });
        }

        [HttpGet]
        [Route("documento/{id}/query/oficinas-finalizadas")]
        public IActionResult GetOficinasFinalizadas([FromRoute]int id)
        {
            var result = _documentoConsulta.GetOficinasFinalizadas(id);
            return _Response(new { dependencias = result.data });
        }

        [HttpPost]
        [Route("documento/actions/anular")]
        public IActionResult AnularDocumento([FromBody]DocumentoRequest request)
        {
            var checkResponse = _documentoConsulta.CheckMesaPartesPuedeAnular(request.id_documento == null ? 0 : request.id_documento.Value);
            if (!checkResponse.check)
                return _Response(statuscode: 403, msg: "No se puede realizar esta acción");

            var result = _documentoComando.Anular(request);
            return _Response(result);
        }

        [HttpPost]
        [Route("documento/actions/agregar-copias")]
        public IActionResult AgregarCopias([FromBody]DocumentoRequest request)
        {
            var checkResponse = _documentoConsulta.CheckMesaPartesPuedeAnular(request.id_documento == null ? 0 : request.id_documento.Value);
            if (!checkResponse.check)
                return _Response(statuscode: 403, msg: "No se puede realizar esta acción");

            var result = _documentoComando.AgregarCopias(request);
            return _Response(result);
        }

        [HttpPost]
        [Route("documento/actions/levantar-observaciones")]
        public IActionResult LevantarObservaciones([FromBody]DocumentoRequest request)
        {
            var checkResponse = _documentoConsulta.CheckMesaPartesPuedeLevantarObservaciones(request.id_documento == null ? 0 : request.id_documento.Value);
            if (!checkResponse.check)
                return _Response(statuscode: 403, msg: "No se puede realizar esta acción");

            var result = _documentoComando.LevantarObservaciones(request);
            return _Response(result);
        }

        [HttpPost]
        [Route("documento/actions/reactivar-registro")]
        public IActionResult ReactivarRegistro([FromBody]DocumentoRequest request)
        {
            var checkResponse = _documentoConsulta.CheckMesaPartesPuedeReactivar(request.id_documento == null ? 0 : request.id_documento.Value);
            if (!checkResponse.check)
                return _Response(statuscode: 403, msg: "No se puede realizar esta acción");

            var result = _documentoComando.ReactivarRegistro(request);
            return _Response(result);
        }

        [HttpGet]
        [Route("documento/{id}/etiqueta-administrado")]
        public IActionResult DocumentoEtiquetaAdministrado([FromRoute]int id)
        {
            var result = _documentoConsulta.GetDocumentoComun(id, "persona");
            return View("Areas/MesaPartes/Views/RegistrarDocumento/DocumentoEtiquetaAdministrado.cshtml", result.data);
        }

        [HttpGet]
        [Route("documento/{id}/etiqueta-produce")]
        public IActionResult DocumentoEtiquetaProduce(int id)
        {
            var result = _documentoConsulta.GetDocumentoComun(id, "persona,movimientos");
            return View("Areas/MesaPartes/Views/RegistrarDocumento/DocumentoEtiquetaProduce.cshtml", result.data);
        }

        [HttpGet]
        [Route("documento/{id}/copias")]
        public IActionResult CopiasDocumento([FromRoute]int id)
        {
            var result = _documentoConsulta.GetDocumentoComun(id, "copias");
            return _Response(new { result.data.copias });
        }

    }
}