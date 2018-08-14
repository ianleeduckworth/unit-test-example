using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UnitTestExample.Core.DependencyInjection;

namespace UnitTestExample.Web.App_Start
{
    public class AutofacWebApiConfig
    {
        public static void Register(ContainerBuilder builder)
        {
            builder.RegisterModule(new MainInstaller());
        }
    }
}