using System.Linq;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using Raven.Client.Embedded;

namespace BetrayalAPI
{
    public static class WebApiConfig
    {
        public static EmbeddableDocumentStore DocumentStore { get; set; }

        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
                

            DocumentStore = new EmbeddableDocumentStore
            {
                DataDirectory = "BetrayalAPI",
                UseEmbeddedHttpServer = true
            };

            DocumentStore.Initialize();
        }
    }
}
