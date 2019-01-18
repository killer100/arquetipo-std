using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prod.STD.Entidades.Anexo;
using Prod.STD.Entidades.Comun;
using Prod.STD.Entidades.Comun.Filters;
using Prod.STD.Entidades.Documento;
using Prod.STD.Presentacion.Configuracion.Proxys;
using Prod.STD.Presentacion.MVC.Controllers;

namespace Prod.STD.Presentacion.MVC.Areas.MesaPartes.Controllers
{

    [Route("api/mesa-partes/buscar-adjuntos")]
    public class BuscarAdjuntosController : CustomBaseController
    {
        private readonly DocumentoConsultaProxy _documentoConsulta;
        private readonly AnexoConsultaProxy _anexoConsulta;
        private readonly AnexoComandoProxy _anexo;
        private readonly ComunConsultaProxy _comunConsultaProxy;

        public BuscarAdjuntosController(AnexoComandoProxy anexo,
            AnexoConsultaProxy anexoConsulta,
            DocumentoConsultaProxy documentoConsulta,
            ComunConsultaProxy comunConsultaProxy)
        {
            _anexo = anexo;
            _anexoConsulta = anexoConsulta;
            _documentoConsulta = documentoConsulta;
            _comunConsultaProxy = comunConsultaProxy;
        }

        #region CRUD ANEXO        

        [HttpGet]
        [Route("anexos/{id_anexo}")]
        public IActionResult Anexo([FromRoute]int id_anexo)
        {
            var anexo = _anexoConsulta.GetAnexo(id_anexo);
            return _Response(anexo);
        }

        [HttpPost]
        [Route("anexos")]
        public IActionResult SaveAnexo([FromBody]AnexoRequest request)
        {
            var usuario = GetUser();
            request.coddep = usuario.IdDependencia;
            request.usuario = usuario.UserName;
            var result = _anexo.SaveAnexo(request);
            return _Response(result);
        }

        [HttpPut]
        [Route("anexos/{id_anexo}")]
        public IActionResult UpdateAnexo([FromRoute]int id_anexo, [FromBody]AnexoRequest request)
        {
            var usuario = GetUser();
            request.usuario = usuario.UserName;

            var checkResponse = _anexoConsulta.CheckCanEditOrRemove(request.id_anexo == null ? 0 : request.id_anexo.Value);
            if (!checkResponse.data.check)
                return _Response(statuscode: 403, msg: "No se puede realizar esta acción");

            var result = _anexo.UpdateAnexo(id_anexo, request);
            return _Response(result);
        }
        #endregion

        [HttpGet]
        [Route("anexos/nuevo-numero")]
        public IActionResult NuevoNumeroAnexo([FromQuery]int id_documento)
        {
            var result = _anexo.NuevoNumero(id_documento);
            return _Response(result);
        }

        [HttpPost]
        [Route("anexos/anular")]
        public IActionResult AnularAnexo([FromBody]AnexoRequest request)
        {

            var checkResponse = _anexoConsulta.CheckCanEditOrRemove(request.id_anexo == null ? 0 : request.id_anexo.Value);
            if (!checkResponse.data.check)
                return _Response(statuscode: 403, msg: "No se puede realizar esta acción");

            var result = _anexo.AnularAnexo(request);
            return _Response(result);
        }

        [HttpGet]
        [Route("documento/ultima-dependencia-pendiente")]
        public IActionResult GetDependenciaPendienteDocumento([FromQuery]int id_documento)
        {
            var dependencias = _documentoConsulta.GetOficinasPendientes(id_documento);
            var dependencia = dependencias.data.FirstOrDefault();
            TrabajadorResponse director = null;

            if (dependencia != null)
            {
                director = _comunConsultaProxy.GetTrabajadores(new TrabajadorFilter
                {
                    codigos_dependencia = new List<int> { dependencia.codigo_dependencia.Value },
                    director = 1
                }).FirstOrDefault();
            }

            return _Response(new { dependencia, director });
        }

        [HttpPost]
        [Route("anexos/search")]
        public IActionResult SearchAnexos([FromBody]AnexoFilter filters)
        {
            var results = _anexoConsulta.SearchAnexos(filters);
            return _Response(results);
        }



        [HttpGet]
        [Route("anexos/{id}/etiqueta-administrado")]
        public IActionResult AnexoEtiquetaAdministrado([FromRoute]int id)
        {
            var result = _anexoConsulta.GetAnexo(id);
            return View("Areas/MesaPartes/Views/BuscarAdjuntos/AnexoEtiquetaAdministrado.cshtml", result.data);
        }

        [HttpGet]
        [Route("anexos/{id}/etiqueta-produce")]
        public IActionResult AnexoEtiquetaProduce(int id)
        {
            var result = _anexoConsulta.GetAnexo(id);
            return View("Areas/MesaPartes/Views/BuscarAdjuntos/AnexoEtiquetaProduce.cshtml", result.data);
        }
    }
}