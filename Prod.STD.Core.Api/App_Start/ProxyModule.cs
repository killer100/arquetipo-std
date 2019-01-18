using System;
using System.IO;
using System.Reflection;
using Autofac;
using Microsoft.Extensions.Configuration;
using Prod.ServiciosExternos;

namespace Prod.STD.Servicios.Host
{
    public class ProxyModule : Autofac.Module
    {
        public static IConfiguration Configuration;
        protected override void Load(ContainerBuilder builder)
        {
            //Proxy
           // var baseFolder = AppDomain.CurrentDomain.BaseDirectory;
            //var rootTemplates = Path.Combine(baseFolder, "PlantillasCorreo");

            string UrlCorreo_Api = Configuration.GetSection("AppSettings:UrlCorreo_Api").Value;

            //EmailSender.Templates = SenderManager.GetEmailTemplates(rootTemplates, EmailSender.Templates);
            //builder.RegisterType<EmailSender>().As<IEmailSender>().WithParameter("route", UrlCorreo_Api);

            var baseFolder = System.IO.Directory.GetCurrentDirectory();
            var rootTemplates = System.IO.Path.Combine(baseFolder, "PlantillasCorreo");
            EmailSender.Templates = SenderManager.GetEmailTemplates(rootTemplates, EmailSender.Templates);
            builder.RegisterType<EmailSender>().As<IEmailSender>().WithParameter("route", UrlCorreo_Api);

            base.Load(builder);
        }
    }
}
