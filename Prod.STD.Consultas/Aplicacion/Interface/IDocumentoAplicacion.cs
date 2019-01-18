using Prod.STD.Entidades.Comun;
using Prod.STD.Entidades.DetalleHojaRuta;
using Prod.STD.Entidades.Documento;
using Prod.STD.Entidades.DocumentoEscaneado;
using Prod.STD.Entidades.DocumentoIngresado;
using Prod.STD.Entidades.FlujoDocumentario;
using Release.Helper.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Consultas.Aplicacion.Interface
{
    public interface IDocumentoAplicacion
    {
        DocumentoResponse GetDocumentoComun(int id_documento, DocumentoOptions options);

        PagedResponse<DocumentoResponse> GetDocumentosMesaPartes(DocumentoFilter filtro, DocumentoOptions options);
        #region Gestión Interna
        int GetDocumentoIdFromHojaTramite(DocumentoFilter filtro);
        PagedResponse<DocumentoResponse> GetDocumentosGestionInterna(DocumentoFilter filters, DocumentoOptions options);
        #endregion


        ICollection<DependenciaResponse> GetOficinasPendientes(int id_documento);

        ICollection<DependenciaResponse> GetOficinasFinalizadas(int id_documento);

        PagedResponse<DocumentoIngresadoResponse> GetDocumentosIngresadosMesaPartes(DocumentoIngresadoFilter filters);

        PagedResponse<DocumentoEscaneadoResponse> GetDocumentosEscaneadosMesaPartes(DocumentoEscaneadoFilter filters);

        PagedResponse<ReporteDocumentoIngresadoResponse> GetReportesDocumentosIngresados(PagedRequest request);

        PagedResponse<ReporteDocumentoEscaneadoResponse> GetReportesDocumentosEscaneados(PagedRequest request);

        bool MesaPartesPuedeModificar(int id_documento);

        bool MesaPartesPuedeAnular(int id_documento);

        bool MesaPartesPuedeAgregarCopia(int id_documento);

        bool MesaPartesPuedeReactivar(int id_documento);

        bool MesaPartesPuedeAdjuntar(int id_documento);

        bool MesaPartesPuedeLevantarObservaciones(int id_documento);

        DetalleHojaRutaResponse GetDetalleHojaDeRuta(int id_documento, string tipo);

        FlujoDocumentarioResponse GetFlujoDocumentario(int id_documento, string tipo);
    }
}
