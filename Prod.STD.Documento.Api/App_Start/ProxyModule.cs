﻿using Autofac;
using Microsoft.Extensions.Configuration;

namespace Prod.STD.Documento.Host
{
    public class ProxyModule : Autofac.Module
    {
        public static IConfiguration Configuration;

        protected override void Load(ContainerBuilder builder)
        {
            //Proxy
           

            base.Load(builder);
        }
    }
}
