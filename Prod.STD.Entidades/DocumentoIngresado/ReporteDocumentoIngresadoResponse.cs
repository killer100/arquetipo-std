using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Entidades.DocumentoIngresado
{
    public class ReporteDocumentoIngresadoResponse
    {
        public int id_reporte { get; set; }
        public string fecha_registro { get; set; }
        public string user_registro { get; set; }
        public string ip_user_registro { get; set; }
        public string numero_reporte { get; set; }
        public int? numero_reporte_int { get; set; }
        public int estado { get; set; }
        public int? coddep_entregado { get; set; }
        public string dep_entregado { get; set; }
        public string siglas_dep_entregado { get; set; }
        public int? codigo_trabajador_entregado { get; set; }
        public string trabajador_entregado { get; set; }
        public int? coddep_recibido { get; set; }
        public string dep_recibido { get; set; }
        public string siglas_dep_recibido { get; set; }
        public int? codigo_trabajador_recibido { get; set; }
        public string trabajador_recibido { get; set; }
        public string fecha_recibido { get; set; }
        public string hora_recibido { get; set; }
        public string fecha_audit { get; set; }
        public string user_audit { get; set; }
        public string ip_audit { get; set; }
        public string observacion { get; set; }
        public string fecha_filtro_ini { get; set; }
        public string fecha_filtro_fin { get; set; }
    }
}
