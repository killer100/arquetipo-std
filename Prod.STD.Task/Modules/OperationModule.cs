using System;
using System.Reflection;
using Autofac;

namespace Prod.STD.Task.Modules
{
    public class OperationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Prod.STD.TaskOperations"))
                .Where(type => type.Name.EndsWith("Operation", StringComparison.Ordinal))
                .AsSelf();

        }
    }
}
