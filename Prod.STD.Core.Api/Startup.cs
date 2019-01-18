using Autofac;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using Serilog;
using System;
using System.Reflection;
using System.IO;
using AutoMapper;
using Prod.STD.Core.Mapping;
using Prod.STD.Core.Api.App_Start;

namespace Prod.STD.Servicios.Host
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

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
        }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAutoMapper(x =>
            {
                x.AddProfile(new STDProfile());
                //x.ForAllMaps((map, exp) => exp.ForAllOtherMembers(opt => opt.Ignore()));
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
            })
            .AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "STD - CORE API", Version = "v1" });
            
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";                
                /*Coment by Alex*/
                //string[] xmls = { "Prod.STD.Core.XML", "Prod.STD.Entidades.XML" };
                //
                //for (var i = 0; i < xmls.Length; i++)
                //{
                //    var xmlFile = xmls[i];
                //    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //    c.IncludeXmlComments(xmlPath);
                //}
                /*End Coment by Alex*/
                //var xmlFile = $"Prod.STD.Core.XML";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //Register Types
            BootstrapperContainer.Configuration = Configuration;
            BootstrapperContainer.Register(builder);

            //Extras
            ExtraModule.Configuration = Configuration;
            builder.RegisterModule<ExtraModule>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddSerilog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "STD - CORE API V1");
            });
            app.Run(context => context.Response.WriteAsync($"<h1 style='color:blue;'>Prod.STD.Core.API Environment: {env.EnvironmentName}</h1>"));
        }
    }
}
