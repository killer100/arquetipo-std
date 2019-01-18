using Microsoft.AspNetCore.Mvc;
using Prod.STD.Entidades.Archivo;
using Prod.STD.Entidades.Comun.Filters;
using Prod.STD.Presentacion.Configuracion.Proxys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Prod.STD.Presentacion.MVC.Controllers.Api
{
    [Route("api/comun")]
    public class ComunController : CustomBaseController
    {
        private readonly ComunConsultaProxy _comunConsulta;
        private readonly DocumentoConsultaProxy _documentoConsulta;
        private readonly ArchivoComandoProxy _archivoComando;
        public ComunController(ComunConsultaProxy comunConsulta, DocumentoConsultaProxy documentoConsulta, ArchivoComandoProxy archivoComando)
        {
            _comunConsulta = comunConsulta;
            _documentoConsulta = documentoConsulta;
            _archivoComando = archivoComando;
        }

        [HttpGet]
        [Route("dependencia")]
        public IActionResult Dependencias([FromQuery]DependenciaFilter filters)
        {
            var result = _comunConsulta.GetDependencias(filters);
            return _Response(result);
        }

        [HttpGet]
        [Route("clase-documento")]
        public IActionResult ClasesDocumento([FromQuery]ClaseDocumentoFilter filters)
        {
            var result = _comunConsulta.GetClasesDocumento(filters);
            return _Response(result);
        }
        [HttpGet]
        [Route("tipos-tratamiento")]
        public IActionResult TiposTratamiento()
        {
            var result = _comunConsulta.GetTiposTratamiento();
            return _Response(result);
        }
        [HttpGet]
        [Route("tipo-resolucion")]
        public IActionResult TiposResolucion()
        {
            var result = _comunConsulta.GetTiposResolucion();
            return _Response(result);
        }

        [HttpGet]
        [Route("clase-tupa")]
        public IActionResult ClasesTupa()
        {
            var result = _comunConsulta.GetClasesTupa();
            return _Response(result);
        }

        [HttpGet]
        [Route("tupa")]
        public IActionResult Tupas([FromQuery]TupaFilter filters)
        {
            var result = _comunConsulta.GetTupas(filters);
            return _Response(result);
        }

        [HttpGet]
        [Route("persona")]
        public IActionResult Personas([FromQuery]PersonaFilter filters)
        {
            var result = _comunConsulta.GetPersonas(filters);
            return _Response(result);
        }

        [HttpGet]
        [Route("requisito-tupa")]
        public IActionResult RequisitosTupa([FromQuery]int id_tupa)
        {
            var result = _comunConsulta.GetRequisitosTupa(id_tupa);
            return _Response(result);
        }

        [HttpGet]
        [Route("tipo-anexo")]
        public IActionResult TiposAnexo()
        {
            var result = _comunConsulta.GetTiposAnexo();
            return _Response(result);
        }

        [HttpGet]
        [Route("trabajador")]
        public IActionResult Trabajadores([FromQuery]string codigos_dependencia)
        {
            var filters = new TrabajadorFilter();

            if (!string.IsNullOrEmpty(codigos_dependencia))
            {
                filters.codigos_dependencia = codigos_dependencia.Split(",").Select(x => int.TryParse(x, out int val) ? val : 0).ToList();
            }

            var result = _comunConsulta.GetTrabajadores(filters);
            return _Response(result);
        }

        [HttpGet]
        [Route("trabajador-director")]
        public IActionResult Trabajadores(int codigo_dependencia)
        {
            var filters = new TrabajadorFilter
            {
                codigos_dependencia = new List<int> { codigo_dependencia },
                director = 1
            };

            var result = _comunConsulta.GetTrabajadores(filters);

            return _Response(result.FirstOrDefault());
        }

        [HttpGet]
        [Route("hoja-tramite-documento-externo")]
        public IActionResult HojaTramiteDocumentoExterno([FromQuery]int id_documento)
        {
            var result = _documentoConsulta.HojaRutaDocumentoExterno(id_documento);

            return _Response(new { hojaTramite = result.data });
        }

        [HttpGet]
        [Route("hoja-tramite-documento-interno")]
        public IActionResult HojaTramiteDocumentoInterno([FromQuery]int id_documento)
        {
            var result = _documentoConsulta.HojaRutaDocumentoInterno(id_documento);

            return _Response(new { hojaTramite = result.data });
        }

        [HttpGet]
        [Route("flujo-documento-externo")]
        public IActionResult FlujoDocumentoExterno([FromQuery]int id_documento)
        {
            var result = _documentoConsulta.FlujoDocumentoExterno(id_documento);

            return _Response(new { flujoDocumentario = result.data });
        }

        [HttpGet]
        [Route("flujo-documento-interno")]
        public IActionResult FlujoDocumentoInterno([FromQuery]int id_documento)
        {
            var result = _documentoConsulta.FlujoDocumentoInterno(id_documento);

            return _Response(new { flujoDocumentario = result.data });
        }
        [HttpPost]
        [Route("subir-archivo-temp")]
        public IActionResult UploadFileTemp()
        {
            var file = Request.Form.Files[0];
            var ms = new MemoryStream();
            file.CopyToAsync(ms);
            byte[] filesBytes = ms.ToArray();
            var request = new ArchivoRequest
            {
                content = filesBytes,
                fileName = file.FileName,
                size = file.Length,
                mimetype = file.ContentType
            };
            var result = _archivoComando.UploadFileTemp(request);
            return _Response(result);
        }
    }
}