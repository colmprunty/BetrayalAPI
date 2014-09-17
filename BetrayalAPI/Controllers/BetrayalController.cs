using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using BetrayalAPI.ActionFilters;
using BetrayalAPI.Models;
using NHibernate;
using NHibernate.Linq;

namespace BetrayalAPI.Controllers
{
    [EnableCors(origins: "http://localhost:5454", headers: "*", methods: "*")]
    [NhSessionManagement]
    public class BetrayalController : ApiController
    {
        private ISession _session;

        [HttpGet]
        public virtual List<Character> GetCharacters()
        {
            _session = WebApiApplication.SessionFactory.GetCurrentSession();
            var list = _session.Query<Character>().ToList();
            return list;
        }

        [HttpPost]
        public virtual void SetCharacter(int id)
        {

        }
    }
}