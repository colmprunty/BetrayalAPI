using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using BetrayalAPI.ActionFilters;
using BetrayalAPI.Models;
using NHibernate;
using NHibernate.Linq;
using NHibernate.Tool.hbm2ddl;

namespace BetrayalAPI.Controllers
{
    [EnableCors(origins: "http://localhost:5454", headers: "*", methods: "*")]
    [NhSessionManagement]
    public class BetrayalController : ApiController
    {
        private ISession _session;
        
        public BetrayalController()
        {
            //_session = WebApiApplication.SessionFactory.GetCurrentSession();
        }

        public ContentResult CreateDatabase()
        {
            WebApiApplication.GetConfig()
                .ExposeConfiguration(x => new SchemaExport(x).Execute(true, true, false))
                .BuildConfiguration();

            return new ContentResult { Content = "Hi"};
        }

        [System.Web.Http.HttpGet]
        public virtual List<Character> GetCharacters()
        {
            _session = WebApiApplication.SessionFactory.GetCurrentSession();
            return _session.Query<Character>().ToList();
        }

        [System.Web.Http.HttpPost]
        public void Reset()
        {
            _session = WebApiApplication.SessionFactory.GetCurrentSession();
            var ox = new Character
            {
                Id = 1,
                Knowledge = new[] {0, 2, 2, 3, 3, 5, 5, 6, 6},
                CurrentKnowledge = 3,
                Sanity = new[] {0, 2, 2, 3, 4, 5, 5, 6, 7},
                CurrentSanity = 3,
                Might = new[] {0, 4, 5, 5, 6, 6, 7, 8, 8},
                CurrentMight = 3,
                Speed = new[] {0, 2, 2, 2, 3, 4, 5, 5, 6},
                CurrentSpeed = 5,
                Name = "Ox Bellows",
            };

            _session.Save(ox);
            
            var flash = new Character
            {
                Id = 2,
                Knowledge = new[] { 0, 2, 3, 3, 4, 5, 5, 5, 7 },
                CurrentKnowledge = 3,
                Sanity = new[] { 0, 1, 2, 3, 4, 5, 5, 5, 7 },
                CurrentSanity = 3,
                Might = new[] { 0, 2, 3, 3, 4, 5, 6, 6, 7 },
                CurrentMight = 3,
                Speed = new[] { 0, 4, 4, 4, 5, 6, 7, 7, 8 },
                CurrentSpeed = 5,
                Name = "Darrin 'Flash' Williams",
            };

            _session.Save(flash);
            _session.Flush();
        }
    }
}