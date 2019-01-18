using Autofac;
using Prod.STD.Task.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;

namespace Prod.STD.Task
{
    static class Home
    {
        [MTAThread]
        static void Main()
        {

#if DEBUG
            Console.WriteLine("Ejecutando en modo consola...");
#endif

            var iocBootstrap = new Bootstrapper();
            var container = iocBootstrap.Build();

            var services = container.Resolve<IEnumerable<ServiceBase>>();
            ServiceBase.Run(services.ToArray());

            
        }
    }
}
