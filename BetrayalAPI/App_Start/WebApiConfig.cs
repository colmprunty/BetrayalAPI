﻿using System.Web.Http;
using Raven.Client.Embedded;

namespace BetrayalAPI
{
    public static class WebApiConfig
    {
        public static EmbeddableDocumentStore DocumentStore { get; set; }

        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            DocumentStore = new EmbeddableDocumentStore
            {
                DataDirectory = "BetrayalAPI",
                UseEmbeddedHttpServer = true
            };

            DocumentStore.Initialize();
        }
    }
}
