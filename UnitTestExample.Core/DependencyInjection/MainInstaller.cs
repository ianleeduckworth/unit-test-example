using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestExample.Core.Helpers.TestHelper;

namespace UnitTestExample.Core.DependencyInjection
{
    public class MainInstaller : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestHelper>().As<ITestHelper>().InstancePerLifetimeScope();
        }
    }
}
