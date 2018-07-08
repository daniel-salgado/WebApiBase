using System.Web.Http;
using WebActivatorEx;
using WebApiBase;
using Swashbuckle.Application;
using System;
using System.Xml.XPath;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace WebApiBase
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "WebApiBase");
                        c.IncludeXmlComments(GetXmlCommentsPath());
                    })
                .EnableSwaggerUi("help/{*assetPath}");
        }

        private static string GetXmlCommentsPath()
        {
            return String.Format(@"{0}\bin\Documentation.xml", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
