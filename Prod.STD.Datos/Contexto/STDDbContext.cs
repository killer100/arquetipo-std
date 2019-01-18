
using Microsoft.EntityFrameworkCore;
using Release.Helper.Data.Core;
using Prod.STD.Datos.Modelo;

using System;

namespace Prod.STD.Datos.Contexto
{
    public partial class STDDbContext : DbContext, IDbContext
    {
        private readonly string _connstr;

        public STDDbContext(string connstr)
        {
            this._connstr = connstr;
        }

        public STDDbContext(DbContextOptions<STDDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(this._connstr))
            {
                optionsBuilder.UseSqlServer(this._connstr, b => b.UseRowNumberForPaging());
            }
        }
        /*Copiado Manualmente desde /MapDB/Prod.STD.Datos */

        public virtual DbSet<anexo> anexo { get; set; }
        public virtual DbSet<documento> documento { get; set; }
        public virtual DbSet<movimiento_documento> movimiento_documento { get; set; }
        public virtual DbSet<clase_documento_interno> clase_documento_interno { get; set; }
        public virtual DbSet<vw_dat_clase_tupa> vw_dat_clase_tupa { get; set; }
        public virtual DbSet<vw_dat_dependencia> vw_dat_dependencia { get; set; }
        public virtual DbSet<vw_dat_tupa> vw_dat_tupa { get; set; }
        public virtual DbSet<resolucion> resolucion { get; set; }
        public virtual DbSet<tipo_resolucion> tipo_resolucion { get; set; }
        public virtual DbSet<v_persona> v_persona { get; set; }
        public virtual DbSet<contador> contador { get; set; }
        public virtual DbSet<vw_dat_requisito_tupa> vw_dat_requisito_tupa { get; set; }
        public virtual DbSet<observaciones_requisitos_tramite> observaciones_requisitos_tramite { get; set; }
        public virtual DbSet<estado_documento> estado_documento { get; set; }
        public virtual DbSet<tipo_anexo> tipo_anexo { get; set; }
        public virtual DbSet<vw_dat_trabajador> vw_dat_trabajador { get; set; }
        public virtual DbSet<finaldoc> finaldoc { get; set; }
        public virtual DbSet<dat_contador_interno> dat_contador_interno { get; set; }
        public virtual DbSet<vw_documentos_sitradoc> vw_documentos_sitradoc { get; set; }
        public virtual DbSet<vw_documentos_sitradoc_digitalizacion> vw_documentos_sitradoc_digitalizacion { get; set; }
        public virtual DbSet<vw_documento_estado> vw_documento_estado { get; set; }
        public virtual DbSet<dat_documento_lf> dat_documento_lf { get; set; }
        public virtual DbSet<dat_documento_copia> dat_documento_copia { get; set; }
        public virtual DbSet<dat_reporte_digitalizado> dat_reporte_digitalizado { get; set; }
        public virtual DbSet<vw_documentos_sitradoc_red> vw_documentos_sitradoc_red { get; set; }
        public virtual DbSet<vw_documentos_sitradoc_red_digitalizacion> vw_documentos_sitradoc_red_digitalizacion { get; set; }
        public virtual DbSet<vw_listado_reportes_digitalizados> vw_listado_reportes_digitalizados { get; set; }
        public virtual DbSet<vw_listado_reportes_documentos> vw_listado_reportes_documentos { get; set; }
        public virtual DbSet<dat_reporte_documentos> dat_reporte_documentos { get; set; }
        public virtual DbSet<tipo_tratamiento> tipo_tratamiento { get; set; }
        public virtual DbSet<documento_cont> documento_cont { get; set; }
        public virtual DbSet<cuentainterno> cuentainterno { get; set; }
        public virtual DbSet<doc_tipo_tratamiento> doc_tipo_tratamiento { get; set; }

    }
}
