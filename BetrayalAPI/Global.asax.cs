using System.Web;
using System.Web.Http;
using BetrayalAPI.ActionFilters;
using BetrayalAPI.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace BetrayalAPI
{
    public class WebApiApplication : HttpApplication
    {
        public static ISessionFactory SessionFactory { get; private set; }

        private void InitializeSessionFactory()
        {
            SessionFactory = Fluently.Configure()
            .Database(MsSqlConfiguration
            .MsSql2012
            .ConnectionString(c => c.FromConnectionStringWithKey("OfflineConnectionString")))
                .Mappings(m => m.FluentMappings
                .AddFromAssemblyOf<CharacterMap>())
            .BuildSessionFactory();
        }

        protected void Application_Start()
        {
            InitializeSessionFactory();
            GlobalConfiguration.Configuration.Filters.Add(new NhSessionManagementAttribute());
        }
    }
}