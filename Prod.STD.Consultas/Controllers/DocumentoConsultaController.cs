using Microsoft.AspNetCore.Mvc;
using Prod.STD.Consultas.Aplicacion.Interface;
using Prod.STD.Core.Controllers.Base;
using Prod.STD.Entidades.Comando;
using Prod.STD.Entidades.Comun;
using Prod.STD.Entidades.DetalleHojaRuta;
using Prod.STD.Entidades.Documento;
using Prod.STD.Entidades.DocumentoEscaneado;
using Prod.STD.Entidades.DocumentoIngresado;
using Prod.STD.Entidades.FlujoDocumentario;
using Prod.STD.Enumerados;
using Release.Helper.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Consultas.Controllers
{
    [Route("[controller]")]
    public class DocumentoConsultaController : BaseController
    {
        private readonly IDocumentoAplicacion _documentoAplicacion;
        public DocumentoConsultaController(IDocumentoAplicacion documentoAplicacion)
        {
            _documentoAplicacion = documentoAplicacion;
        }

        /// <summary>
        /// Busca Documentos para el módulo de mesa de partes
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="related"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("search/mesa-partes")]
        public PagedResponse<DocumentoResponse> SearchMesaPartes([FromBody]DocumentoFilter filtro, [FromQuery]string related)
        {
            filtro.id_tipos_documento = new int?[] { 1, 2 };
            var options = buildDocumentoOptions(related);
            return _documentoAplicacion.GetDocumentosMesaPartes(filtro, options);
        }

        [HttpGet]
        [Route("search/mesa-partes/ingresados")]
        public PagedResponse<DocumentoIngresadoResponse> SearchMesaPartesDocumentosIngresados([FromBody]DocumentoIngresadoFilter filtro)
        {
            return _documentoAplicacion.GetDocumentosIngresadosMesaPartes(filtro);
        }

        [HttpGet]
        [Route("search/mesa-partes/escaneados")]
        public PagedResponse<DocumentoEscaneadoResponse> SearchMesaPartesDocumentosEscaneados([FromBody]DocumentoEscaneadoFilter filtro)
        {
            return _documentoAplicacion.GetDocumentosEscaneadosMesaPartes(filtro);
        }

        [HttpGet]
        [Route("search/mesa-partes/reportes-documentos-ingresados")]
        public PagedResponse<ReporteDocumentoIngresadoResponse> SearchMesaPartesReportesDocumentosIngresados([FromBody]PagedRequest request)
        {
            return _documentoAplicacion.GetReportesDocumentosIngresados(request);
        }

        [HttpGet]
        [Route("search/mesa-partes/reportes-documentos-escaneados")]
        public PagedResponse<ReporteDocumentoEscaneadoResponse> SearchMesaPartesReportesDocumentosEscaneados([FromBody]PagedRequest request)
        {
            return _documentoAplicacion.GetReportesDocumentosEscaneados(request);
        }

        #region Gestión Interna
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filtro"></param>
        /// <param name="related"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("search/gestion-interna")]
        public PagedResponse<DocumentoResponse> SearchGestionInterna([FromBody]DocumentoFilter filtro, [FromQuery]string related)
        {
            filtro.id_tipos_documento = null;
            if (filtro.tipo_hoja_tramite == "E") filtro.id_tipos_documento = new int?[] { 1, 2 };
            if (filtro.tipo_hoja_tramite == "I") filtro.id_tipos_documento = new int?[] { 3, 4, 5 };
            switch (filtro.estado_documento_interno)
            {
                case (int)ESTADODOC_INTERNO.POR_ACEPTAR:
                    filtro.mvEnviado = 1; filtro.mvDerivado = 0; filtro.mvFinalizado = 0; filtro.isDocumentoRecibido = false;
                    break;
                case (int)ESTADODOC_INTERNO.ACEPTADO:
                    filtro.mvEnviado = 1; filtro.mvDerivado = 0; filtro.mvFinalizado = 0; filtro.isDocumentoRecibido = true;
                    break;
                default:
                    break;
            }
            var options = buildDocumentoOptions(related);
            return _documentoAplicacion.GetDocumentosGestionInterna(filtro, options);
        }
        [HttpGet]
        [Route("search/gestion-interna/GetDocFromHojaTramite")]
        public CommandResponse<DocumentoResponse> GetDocFromHojaTramite([FromBody]DocumentoFilter filtro)
        {            
            return this.TryCatch(() =>
            {
                var id = _documentoAplicacion.GetDocumentoIdFromHojaTramite(filtro);
                var options = buildDocumentoOptions("");
                var documento = id == 0 ? new DocumentoResponse() : _documentoAplicacion.GetDocumentoComun(id, options);
                return _Response(data: documento);
            });
        }
        #endregion

        /// <summary>
        /// Busca documentos por filtros generales
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("search/general")]
        public PagedResponse<DocumentoResponse> SearchGeneral([FromBody]DocumentoFilter filtro)
        {
            return null;
        }

        /// <summary>
        /// Retorna Información de un documento en general
        /// </summary>
        /// <param name="id">
        /// Id de documento a buscar.
        /// Tipo: int
        /// </param>
        /// <param name="related">
        /// Retorna el detalle de las entidades relacionadas. Las entidades deben ir separadas por comas ","
        /// Tipo: string
        /// opciones disponibles: persona, estado, movimientos, clase_documento, requisitos, tupa
        /// Ejemplos: related=persona | related=persona,estado,movimientos
        /// </param>
        /// <returns></returns>
        [HttpGet]
        [Route("comun/{id}")]
        public CommandResponse<DocumentoResponse> GetDocumentoComun([FromRoute]int id, [FromQuery]string related)
        {
            return this.TryCatch(() =>
            {
                var options = buildDocumentoOptions(related);
                var documento = _documentoAplicacion.GetDocumentoComun(id, options);
                return _Response(data: documento);
            });
        }

        //============================================================================
        // CONSULTAS SOBRE UN DOCUMENTO
        //============================================================================
        [HttpGet]
        [Route("query/{id_documento}/oficinas-pendientes")]
        public CommandResponse<ICollection<DependenciaResponse>> GetOficinasPendientes([FromRoute]int id_documento)
        {
            return this.TryCatch(() =>
            {
                var documento = _documentoAplicacion.GetOficinasPendientes(id_documento);
                return _Response(data: documento);
            });
        }

        [HttpGet]
        [Route("query/{id_documento}/oficinas-finalizadas")]
        public CommandResponse<ICollection<DependenciaResponse>> GetOficinasFinalizadas([FromRoute]int id_documento)
        {
            return this.TryCatch(() =>
            {
                var pendientes = _documentoAplicacion.GetOficinasFinalizadas(id_documento);
                return _Response(data: pendientes);
            });
        }

        [HttpGet]
        [Route("query/{id_documento}/check-mesa-partes-puede-modificar")]
        public CheckResponse CheckMesaPartesPuedeModificar([FromRoute]int id_documento)
        {
            return new CheckResponse { check = _documentoAplicacion.MesaPartesPuedeModificar(id_documento) };
        }

        [HttpGet]
        [Route("query/{id_documento}/check-mesa-partes-puede-anular")]
        public CheckResponse CheckMesaPartesPuedeAnular([FromRoute]int id_documento)
        {
            return new CheckResponse { check = _documentoAplicacion.MesaPartesPuedeAnular(id_documento) };
        }

        [HttpGet]
        [Route("query/{id_documento}/check-mesa-partes-puede-agregar-copia")]
        public CheckResponse CheckMesaPartesPuedeAgregarCopia([FromRoute]int id_documento)
        {
            return new CheckResponse { check = _documentoAplicacion.MesaPartesPuedeAgregarCopia(id_documento) };
        }

        [HttpGet]
        [Route("query/{id_documento}/check-mesa-partes-puede-reactivar")]
        public CheckResponse CheckMesaPartesPuedeReactivar([FromRoute]int id_documento)
        {
            return new CheckResponse { check = _documentoAplicacion.MesaPartesPuedeReactivar(id_documento) };
        }

        [HttpGet]
        [Route("query/{id_documento}/check-mesa-partes-puede-adjuntar")]
        public CheckResponse CheckMesaPartesPuedeAdjuntar([FromRoute]int id_documento)
        {
            return new CheckResponse { check = _documentoAplicacion.MesaPartesPuedeAdjuntar(id_documento) };
        }

        [HttpGet]
        [Route("query/{id_documento}/check-mesa-partes-puede-levantar-observaciones")]
        public CheckResponse CheckMesaPartesPuedeLevantarObservaciones([FromRoute]int id_documento)
        {
            return new CheckResponse { check = _documentoAplicacion.MesaPartesPuedeLevantarObservaciones(id_documento) };
        }

        [HttpGet]
        [Route("query/{id_documento}/hoja-ruta-interna")]
        public CommandResponse<DetalleHojaRutaResponse> HojaRutaDocumentoInterno([FromRoute]int id_documento)
        {
            return this.TryCatch(() =>
            {
                var hojaRuta = _documentoAplicacion.GetDetalleHojaDeRuta(id_documento, "I");
                return _Response(data: hojaRuta);
            });
        }

        [HttpGet]
        [Route("query/{id_documento}/hoja-ruta-externa")]
        public CommandResponse<DetalleHojaRutaResponse> HojaRutaDocumentoExterno([FromRoute]int id_documento)
        {
            return this.TryCatch(() =>
            {
                var hojaRuta = _documentoAplicacion.GetDetalleHojaDeRuta(id_documento, "E");
                return _Response(data: hojaRuta);
            });
        }

        [HttpGet]
        [Route("query/{id_documento}/flujo-documento-interno")]
        public CommandResponse<FlujoDocumentarioResponse> FlujoDocumentoInterno([FromRoute]int id_documento)
        {
            return this.TryCatch(() =>
            {
                var hojaRuta = _documentoAplicacion.GetFlujoDocumentario(id_documento, "I");
                return _Response(data: hojaRuta);
            });
        }

        [HttpGet]
        [Route("query/{id_documento}/flujo-documento-externo")]
        public CommandResponse<FlujoDocumentarioResponse> FlujoDocumentoExterno([FromRoute]int id_documento)
        {
            return this.TryCatch(() =>
            {
                var hojaRuta = _documentoAplicacion.GetFlujoDocumentario(id_documento, "E");
                return _Response(data: hojaRuta);
            });
        }


        //============================================================================
        // HELPERS PARA LA BUSQUEDA DE DOCUMENTOS
        //============================================================================
        #region HELPERS
        private DocumentoOptions buildDocumentoOptions(string related)
        {
            var options = new DocumentoOptions();

            if (!string.IsNullOrEmpty(related))
            {
                ICollection<string> relatedOptions = related.Split(",");
                foreach (var op in relatedOptions)
                {
                    switch (op.Trim())
                    {
                        case "persona":
                            options.withPersona = true;
                            break;
                        case "movimientos":
                            options.withMovimientos = true;
                            break;
                        case "estado":
                            options.withEstado = true;
                            break;
                        case "clase_documento":
                            options.withClaseDocumento = true;
                            break;
                        case "requisitos":
                            options.withRequisitos = true;
                            break;
                        case "tupa":
                            options.withTupa = true;
                            break;
                        case "anexos":
                            options.withAnexos = true;
                            break;
                        case "hoja_tramite":
                            options.withHojaTramite = true;
                            break;
                        case "copias":
                            options.withCopias = true;
                            break;
                    }
                }
            }

            return options;
        }
        #endregion
    }
}
