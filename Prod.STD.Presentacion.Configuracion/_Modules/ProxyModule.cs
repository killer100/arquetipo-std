using Autofac;
using Microsoft.Extensions.Configuration;
using Prod.ServiciosExternos;
using Release.Helper.ReportingServices;
using System;
using System.Reflection;

namespace Prod.STD.Presentacion.Configuracion._Modules
{
    public class ProxyModule : Autofac.Module
    {
        public static AppConfig AppConfig;
        public static IConfiguration Configuration;
        protected override void Load(ContainerBuilder builder)
        {
            //Proxy Local
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Prod.STD.Presentacion.Configuracion")))
               .Where(type => type.Name.EndsWith("Proxy", StringComparison.Ordinal))
               .AsSelf();

            //Reportes SSRS
            /*var rc = new Release.Helper.ReportingServices.ReportConfig();
            Configuration.GetSection("AppConfig:ReportConfig").Bind(rc);
            builder.RegisterType<ReportManager>().As<IReportManager>().WithParameter("config", rc);*/

            //Proxy Externos
            builder.RegisterType<AnioServicio>().As<IAnioServicio>().WithParameter("baseUrl", AppConfig.Urls.URL_ANIO_API);
            builder.RegisterType<ReniecServicio>().As<IReniecServicio>().WithParameter("baseUrl", AppConfig.Urls.URL_RENIEC_API);
            builder.RegisterType<SunatServicio>().As<ISunatServicio>().WithParameter("baseUrl", AppConfig.Urls.URL_SUNAT_API);
            builder.RegisterType<MigracionesServicio>().As<IMigracionesServicio>().WithParameter("baseUrl", AppConfig.Urls.URL_MIGRACIONES_API);
            builder.RegisterType<UbigeoServicio>().As<IUbigeoServicio>().WithParameter("baseUrl", AppConfig.Urls.URL_UBIGEO);

            string urlCorreoApi = AppConfig.Urls.URL_CORREO_API;
            builder.RegisterType<EmailSender>().As<IEmailSender>().WithParameter("route", urlCorreoApi);

            base.Load(builder);
        }
    }
}
