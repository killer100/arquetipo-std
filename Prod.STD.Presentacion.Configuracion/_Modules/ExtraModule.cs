using Autofac;
using Microsoft.AspNetCore.Hosting;

namespace Prod.STD.Presentacion.Configuracion._Modules
{
    public class ExtraModule : Autofac.Module
    {
        public static AppConfig AppConfig;
        public static AppSettings AppSettings;
        public static IHostingEnvironment Environment;

        protected override void Load(ContainerBuilder builder)
        {            
            base.Load(builder);
        }
    }
}
