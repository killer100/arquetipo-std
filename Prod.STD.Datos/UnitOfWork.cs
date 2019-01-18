using Prod.STD.Entidades;
using Release.Helper.Data.Core;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using Release.Helper;
using Prod.STD.Entidades.Documento;
using Prod.STD.Entidades.HojaRuta;
using Prod.STD.Entidades.Anexo;
using Prod.STD.Entidades.Correspondencia;
using Prod.STD.Entidades.Resolucion;
using Prod.STD.Entidades.FlujoTrabajador;
using Prod.STD.Enumerados;

namespace Prod.STD.Datos
{
    public class UnitOfWork : BaseUnitOfWork, IUnitOfWork
    {
        public UnitOfWork(IDbContext ctx) : base(ctx, true)
        {
        }

        /*
        public IEnumerable<DetalleExpedienteResponse> GetDetalleExpedienteSP(DetalleExpedienteFilterRequest filtro)
        {
            var para = new Parameter[]
            {
                new Parameter("@id",filtro.id_documento)
            };
            var xmlResult = this.ExecuteXmlReader("dbo.p_DOCUMENTO_DETALLE_List", CommandType.StoredProcedure, ref para);
            var movimientos = XmlManager.ReaderFromDataXml<DetalleExpedienteResponse>(xmlResult, "order");
            return movimientos;
        }
        */
        //http://dapper-tutorial.net/dapper
        //public IEnumerable<DetalleExpedienteResponse> GetDetalleExpedienteSP(DetalleExpedienteFilterRequest filtro)
        //{
        //    
        //    var para = new DynamicParameters();
        //    para.Add("@id", filtro.id_documento, direction: ParameterDirection.Input);
        //
        //
        //    var items = this.Connection.Query<DetalleExpedienteResponse>(
        //        "dbo.usp_obtener_participante", para
        //        , commandType: CommandType.StoredProcedure
        //        // ,transaction: this.Transaction
        //    );
        //
        //    return items.ToList();
        //}

        //public IEnumerable<RegistroResponse> ListByFiltroSP(RegistroFilterRequest filtro)
        //{
        //    var para = new Parameter[]
        //    {
        //        new Parameter("@FILTRO", filtro.filtro,ParameterDirection.Input),
        //        new Parameter("@PAGE", filtro.Page),
        //        new Parameter("@ROWS", filtro.PageSize)
        //    };
        //    var result = this.ExecuteReader<RegistroResponse>("dbo.p_REGISTROS_ListByFiltro",
        //        CommandType.StoredProcedure, ref para);
        //    return result;
        //}

        //public RegistroResponse GetDetailsByIDSP(RegistroFilterRequest filtro)
        //{
        //    var para = new Parameter[]
        //    {
        //        new Parameter("@ID_REGISTRO", filtro.id_registro)
        //    };
        //    var result = this.ExecuteScalar<RegistroResponse>("dbo.p_REGISTROS_GetDetailsByID",
        //        CommandType.StoredProcedure, ref para);
        //    return result;
        //}

        //public IEnumerable<TupaResponse> ListByCodigoTributo(TupaFilterRequest filtro)
        //{
        //    var para = new Parameter[]
        //    {
        //        new Parameter("@CODIGO_TRIBUTO", filtro.codigo_tributo)
        //    };
        //    var result = this.ExecuteReader<TupaResponse>("dbo.p_TUPA_ListByCodigoTributo", CommandType.StoredProcedure,
        //        ref para);
        //    return result;
        //}

        public string EstablecerFechaMaxPlazo(int id_documento)
        {
            var para = new Parameter[]
            {
                new Parameter("@ID_DOCUMENTO", id_documento)
            };
            var result = this.ExecuteScalar<string>("select dbo.fn_establecer_fecha_max_plazo(@ID_DOCUMENTO)", CommandType.Text,
                ref para);
            return result;
        }

        public void p_DOCUMENTO_DIGITALIZADO_Crud(int id_documento, int id_anexo, string user, string ip, int accion, int id_reporte)
        {
            var para = new Parameter[]
            {
                new Parameter("@id_documento", id_documento),
                new Parameter("@id_anexo", id_anexo),
                new Parameter("@user", user),
                new Parameter("@ip_user", ip),
                new Parameter("@accion", accion),
                new Parameter("@id_reporte", id_reporte)
            };
            this.ExecuteNonQuery("web_tramite.p_DOCUMENTO_DIGITALIZADO_Crud", ref para);
        }

        public void p_DOCUMENTO_ESTADO_Crud(int id_documento, int id_anexo, string user, string ip, int accion, int id_reporte)
        {
            var para = new Parameter[]
            {
                new Parameter("@id_documento", id_documento),
                new Parameter("@id_anexo", id_anexo),
                new Parameter("@user", user),
                new Parameter("@ip_user", ip),
                new Parameter("@accion", accion),
                new Parameter("@id_reporte", id_reporte)
            };
            this.ExecuteNonQuery("web_tramite.p_DOCUMENTO_ESTADO_Crud", ref para);
        }

        public DocumentoHojaTramiteResponse p_DOCUMENTO_GET_HOJA_TRAMITE_EXTERNA(int id_documento)
        {
            var para = new Parameter[]
            {
                new Parameter("@ID_DOCUMENTO", id_documento),
            };
            var result = this.ExecuteReader<DocumentoHojaTramiteResponse>("usr_std.p_DOCUMENTO_GET_HOJA_TRAMITE_EXTERNA", CommandType.StoredProcedure,
                ref para);
            return result.FirstOrDefault();
        }

        public DocumentoHojaTramiteResponse p_DOCUMENTO_GET_HOJA_TRAMITE_INTERNA(int id_documento)
        {
            var para = new Parameter[]
            {
                new Parameter("@ID_DOCUMENTO", id_documento),
            };
            var result = this.ExecuteReader<DocumentoHojaTramiteResponse>("usr_std.p_DOCUMENTO_GET_HOJA_TRAMITE_INTERNA", CommandType.StoredProcedure,
                ref para);
            return result.FirstOrDefault();
        }

        public IEnumerable<HojaRutaResponse> p_DOCUMENTO_GET_HOJA_RUTA(int id_documento)
        {
            var para = new Parameter[]
            {
                new Parameter("@ID_DOCUMENTO", id_documento),
            };
            var result = this.ExecuteReader<HojaRutaResponse>("usr_std.p_DOCUMENTO_GET_HOJA_RUTA", CommandType.StoredProcedure,
                ref para);
            return result;
        }

        public IEnumerable<AnexoResponse> p_DOCUMENTO_FLUJO_GET_ANEXOS(int id_documento)
        {
            var para = new Parameter[]
            {
                new Parameter("@ID_DOCUMENTO", id_documento),
            };
            var result = this.ExecuteReader<AnexoResponse>("usr_std.p_DOCUMENTO_FLUJO_GET_ANEXOS", CommandType.StoredProcedure,
                ref para);
            return result;
        }

        public IEnumerable<HojaRutaResponse> p_DOCUMENTO_FLUJO_GET_FLUJO_DEPENDENCIAS(int id_documento)
        {
            var para = new Parameter[]
            {
                new Parameter("@ID_DOCUMENTO", id_documento),
            };
            var result = this.ExecuteReader<HojaRutaResponse>("usr_std.p_DOCUMENTO_FLUJO_GET_FLUJO_DEPENDENCIAS", CommandType.StoredProcedure,
                ref para);
            return result;
        }

        public IEnumerable<CorrespondenciaResponse> p_DOCUMENTO_FLUJO_GET_CORRESPONDENCIAS(int id_documento)
        {
            var para = new Parameter[]
            {
                new Parameter("@ID_DOCUMENTO", id_documento),
            };
            var result = this.ExecuteReader<CorrespondenciaResponse>("usr_std.p_DOCUMENTO_FLUJO_GET_CORRESPONDENCIAS", CommandType.StoredProcedure,
                ref para);
            return result;
        }

        public IEnumerable<ResolucionResponse> p_DOCUMENTO_FLUJO_GET_RESOLUCIONES(int id_documento)
        {
            var para = new Parameter[]
            {
                new Parameter("@ID_DOCUMENTO", id_documento),
            };
            var result = this.ExecuteReader<ResolucionResponse>("usr_std.p_DOCUMENTO_FLUJO_GET_RESOLUCIONES", CommandType.StoredProcedure,
                ref para);
            return result;
        }

        public IEnumerable<FlujoTrabajadorResponse> p_DOCUMENTO_FLUJO_GET_FLUJO_TRABAJADORES(int id_documento)
        {
            var para = new Parameter[]
            {
                new Parameter("@ID_DOCUMENTO", id_documento),
            };
            var result = this.ExecuteReader<FlujoTrabajadorResponse>("usr_std.p_DOCUMENTO_FLUJO_GET_FLUJO_TRABAJADORES", CommandType.StoredProcedure,
                ref para);
            return result;
        }

        public void InsertarDocumentoCont(int id_documento)
        {
            Modelo.documento_cont documento_cont = new Modelo.documento_cont
            {
                ID_DOCUMENTO = id_documento,
                CANT_COPIAS = Context.Query<Modelo.dat_documento_copia>().Where(x => x.ID_DOCUMENTO == id_documento && x.ESTADO == ESTADO_DOCUMENTO_COPIA.ACTIVO).Count(),
                CANT_ADJUNTOS = Context.Query<Modelo.anexo>().Where(x => x.ID_DOCUMENTO == id_documento && x.ESTADO_ADJUNTO == ESTADO_ADJUNTO.ACTIVO).Count()
            };

            Context.Add(documento_cont);

            Save();
        }

        public string FN_GENERA_CLAVE_DOCUMENTO_TRAMITE(string num_tram_documentario)
        {
            var para = new Parameter[]
            {
                new Parameter("@NUM_TRAM_DOCUMENTARIO", num_tram_documentario)
            };
            var result = this.ExecuteScalar<string>("select usr_std.FN_GENERA_CLAVE_DOCUMENTO_TRAMITE(@NUM_TRAM_DOCUMENTARIO)", CommandType.Text,
                ref para);

            return result;
        }

    }
}
