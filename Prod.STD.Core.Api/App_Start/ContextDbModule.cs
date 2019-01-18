using Autofac;
using Microsoft.Extensions.Configuration;
using Prod.STD.Datos.Contexto;
using Prod.STD.Datos;

using Release.Helper.Data.Core;
using System;
using System.Reflection;

namespace Prod.STD.Servicios.Host
{
    public class ContextDbModule : Autofac.Module
    {
        public static IConfiguration Configuration;

        protected override void Load(ContainerBuilder builder)
        {

            #region Base Context

            //Conexion
            string connectionString = Configuration.GetSection("ConnectionStrings:STDDbContext").Value;
            //Context           
            builder.RegisterType<STDDbContext>().Named<IDbContext>("context").WithParameter("connstr", connectionString).InstancePerLifetimeScope();
            //Resolver UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().WithParameter((c, p) => true, (c, p) => p.ResolveNamed<IDbContext>("context"));                       
            //-> Aplicacion
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Prod.STD.Core")))
                .Where(t => t.Name.EndsWith("Aplicacion", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Prod.STD.Comandos")))
                .Where(t => t.Name.EndsWith("Aplicacion", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Prod.STD.Consultas")))
                   .Where(t => t.Name.EndsWith("Aplicacion", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
                   .AsImplementedInterfaces();
            //-> Validacion
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Prod.STD.Core")))
                .Where(t => t.Name.EndsWith("Validacion", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
                .AsSelf();
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Prod.STD.Comandos")))
               .Where(t => t.Name.EndsWith("Validacion", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
               .AsSelf();
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Prod.STD.Consultas")))
               .Where(t => t.Name.EndsWith("Validacion", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
               .AsSelf();
            //-> Proceso
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Prod.STD.Core")))
                .Where(t => t.Name.EndsWith("Proceso", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
                .AsSelf();
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Prod.STD.Comandos")))
                .Where(t => t.Name.EndsWith("Proceso", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
                .AsSelf();
            builder.RegisterAssemblyTypes(Assembly.Load(new AssemblyName("Prod.STD.Consultas")))
                .Where(t => t.Name.EndsWith("Proceso", StringComparison.Ordinal) && t.GetTypeInfo().IsClass)
                .AsSelf();

            #endregion            
        }

    }
}
