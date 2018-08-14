using Newtonsoft.Json;
using Swashbuckle.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace UnitTestExample.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.EnableSwagger(x =>
            {
                x.SingleApiVersion("v1", "Test API to demonstrate unit test structure");
                x.RootUrl(m =>
                {
                    var virtualPathRoot = m.GetRequestContext().VirtualPathRoot;

                    var schemeAndHost = $"{m.RequestUri.Scheme}://{m.RequestUri.Host}:{m.RequestUri.Port}";
                    return new Uri(new Uri(schemeAndHost, UriKind.Absolute), virtualPathRoot).AbsoluteUri;
                });
                x.IncludeXmlComments($@"{AppDomain.CurrentDomain.BaseDirectory}bin\UnitTestExample.Web.XML");
                x.DescribeAllEnumsAsStrings();
            }).EnableSwaggerUi(x =>
            {
                x.DisableValidator();
            });

            //use Newtonsoft.Json.Formatting.Indented for serialization
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
        }
    }
}
