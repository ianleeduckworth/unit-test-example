using Autofac;
using Autofac.Extras.CommonServiceLocator;
using Autofac.Integration.WebApi;
using CommonServiceLocator;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using UnitTestExample.Web.App_Start;

namespace UnitTestExample.Web
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterWebApiFilterProvider(config);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiModelBinderProvider();
            AutofacWebApiConfig.Register(builder);
            var container = builder.Build();

            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
        }
    }
}
