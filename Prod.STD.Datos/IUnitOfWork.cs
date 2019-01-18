
using Prod.STD.Entidades;
using Prod.STD.Entidades.Anexo;
using Prod.STD.Entidades.Correspondencia;
using Prod.STD.Entidades.Documento;
using Prod.STD.Entidades.FlujoTrabajador;
using Prod.STD.Entidades.HojaRuta;
using Prod.STD.Entidades.Resolucion;
using Release.Helper.Data.ICore;
using System.Collections.Generic;

namespace Prod.STD.Datos
{
    public interface IUnitOfWork : IBaseUnitOfWork
    {
        //IEnumerable<DetalleExpedienteResponse> GetDetalleExpedienteSP(DetalleExpedienteFilterRequest filtro);
        //IEnumerable<RegistroResponse> ListByFiltroSP(RegistroFilterRequest filtro);
        //RegistroResponse GetDetailsByIDSP(RegistroFilterRequest filtro);
        //IEnumerable<TupaResponse> ListByCodigoTributo(TupaFilterRequest filtro);
        string EstablecerFechaMaxPlazo(int id_documento);

        void p_DOCUMENTO_DIGITALIZADO_Crud(int id_documento, int id_anexo, string user, string ip, int accion, int id_reporte);

        void p_DOCUMENTO_ESTADO_Crud(int id_documento, int id_anexo, string user, string ip, int accion, int id_reporte);

        DocumentoHojaTramiteResponse p_DOCUMENTO_GET_HOJA_TRAMITE_EXTERNA(int id_documento);

        DocumentoHojaTramiteResponse p_DOCUMENTO_GET_HOJA_TRAMITE_INTERNA(int id_documento);

        IEnumerable<HojaRutaResponse> p_DOCUMENTO_GET_HOJA_RUTA(int id_documento);

        IEnumerable<AnexoResponse> p_DOCUMENTO_FLUJO_GET_ANEXOS(int id_documento);

        IEnumerable<HojaRutaResponse> p_DOCUMENTO_FLUJO_GET_FLUJO_DEPENDENCIAS(int id_documento);

        IEnumerable<CorrespondenciaResponse> p_DOCUMENTO_FLUJO_GET_CORRESPONDENCIAS(int id_documento);

        IEnumerable<ResolucionResponse> p_DOCUMENTO_FLUJO_GET_RESOLUCIONES(int id_documento);

        IEnumerable<FlujoTrabajadorResponse> p_DOCUMENTO_FLUJO_GET_FLUJO_TRABAJADORES(int id_documento);

        void InsertarDocumentoCont(int id_documento);

        string FN_GENERA_CLAVE_DOCUMENTO_TRAMITE(string num_tram_documentario);
    }
}
