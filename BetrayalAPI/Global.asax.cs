using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BetrayalAPI.ActionFilters;
using BetrayalAPI.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;

namespace BetrayalAPI
{
    public class WebApiApplication : HttpApplication
    {
        public static ISessionFactory SessionFactory { get; private set; }

        public static FluentConfiguration GetConfig()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration
                    .MsSql2012
                    .ConnectionString(c => c.FromConnectionStringWithKey("OfflineConnectionString")))
                .Mappings(m => m.FluentMappings
                    .AddFromAssemblyOf<CharacterMap>());
        }

        private static void InitializeSessionFactory()
        {
            SessionFactory = 
                GetConfig()
                .CurrentSessionContext<WebSessionContext>()
                .BuildSessionFactory();
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeSessionFactory();
            GlobalConfiguration.Configuration.Filters.Add(new NhSessionManagementAttribute());
        }
    }
}