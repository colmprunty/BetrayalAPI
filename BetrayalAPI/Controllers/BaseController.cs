using System.Web.Http;
using BetrayalAPI.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace BetrayalAPI.Controllers
{
    public class BaseController : ApiController
    {
        public ISession Session { get; set; }

        public ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
            .Database(MsSqlConfiguration
            .MsSql2012
            .ConnectionString(c => c.FromConnectionStringWithKey("OfflineConnectionString")))
                .Mappings(m => m.FluentMappings
                .AddFromAssemblyOf<CharacterMap>())
            .BuildSessionFactory();
        }
    }
}