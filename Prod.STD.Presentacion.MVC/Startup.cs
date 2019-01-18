using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Prod.Seguridad.Auth;
using Prod.STD.Presentacion.Configuracion._Modules;
using Release.Helper.WebKoMvc.Common;
using Release.Helper.WebKoMvc.Controllers;
using Serilog;
using System;


namespace Prod.STD.Presentacion.MVC
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public IHostingEnvironment Environment { get; set; }

        public Startup(IHostingEnvironment env)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .Enrich.FromLogContext()
                .WriteTo.File("Log/Log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            var basePath = AppDomain.CurrentDomain.BaseDirectory; //#SDK 2.00

            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            Environment = env;

            BaseController.StartConfig(); //Leer Config     
            SecurityConfig.Init((IConfigurationRoot)Configuration);
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();
            app.UseAuthentication();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                //Areas(routes);
                routes.MapRoute(
                    name: "default",
                    template: "api/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "catch-all",
                    template: "{*url}",
                    defaults: new { controller = "Home", action = "Index" }
                );
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //Encryts
            HelperHttp.AllowEncrypt = false;
            //HelperHttp.SeparetorValue = "xZxS%jqm,nr%Ft1Jr,60Vc%UNh,6e9hv9%M,K%NZThUV,JT%WG5aU,hn8q%xb4,QO1%qim9,EjuRBck%,eX1%P2Gd";
            HelperHttp.DomainSecure = SecurityConfig.Settings.DomainSecure;
            HelperHttp.WebRootPath = Environment.WebRootPath;

            //Register Types
            BootstrapperContainer.Configuration = this.Configuration;
            BootstrapperContainer.Environment = this.Environment;
            BootstrapperContainer.Register(builder);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomAuthentication(false);

            services.AddMvc(o =>
            {
                o.Filters.Add(new ProducesAttribute("application/json"));
                o.Filters.Add(new Release.Helper.WebKoMvc.Filters.SecureResponseRequestAttribute());
            }).AddJsonOptions(o =>
                {
                    o.SerializerSettings.ContractResolver = new DefaultContractResolver();
                });
        }

        private void Areas(IRouteBuilder routes)
        {
            routes.MapRoute(
                name: "area",
                template: "api/{area:exists}/{controller=Home}/{action=Index}/{id?}");
        }


    }
}
