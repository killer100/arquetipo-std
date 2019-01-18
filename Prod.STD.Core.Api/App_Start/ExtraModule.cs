using Autofac;
using Microsoft.Extensions.Configuration;
using Prod.STD.Entidades._Base;

namespace Prod.STD.Core.Api.App_Start
{
    public class ExtraModule : Autofac.Module
    {
        public static IConfiguration Configuration;
        protected override void Load(ContainerBuilder builder)
        {
            var appSettings = new AppSettings
            {
                RemotePathTempDocs = Configuration.GetSection("AppSettings:RemotePathTempDocs").Value
            };

            builder.Register(c => appSettings).SingleInstance();

            base.Load(builder);
        }
    }
}
