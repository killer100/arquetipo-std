using System;
using System.Collections.Generic;
using System.Text;

namespace Prod.STD.Presentacion.Configuracion
{
    public class AppConfig
    {
        public Urls Urls { get; set; }
        public ReportConfig ReportConfig { get; set; }
    }
    public class Urls
    {
        public string URL_GA_UI { get; set; }
        public string URL_STD_Core_API { get; set; }

        public string URL_MIGRACIONES_API { get; set; }
        public string URL_RENIEC_API { get; set; }
        public string URL_SUNAT_API { get; set; }
        public string URL_UBIGEO { get; set; }
        public string URL_CORREO_API { get; set; }
        public string URL_ANIO_API { get; set; }
    }

    public class ReportConfig
    {
        public string UrlReportServer { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public string ReportFolder { get; set; }
    }
}
