using System.Web.Http.Cors;
using BetrayalAPI.Models;

namespace BetrayalAPI.Controllers
{
    [EnableCors(origins: "http://localhost:5454", headers: "*", methods: "*")]
    public class BetrayalController : RavenController
    {
        public void Reset()
        {
            foreach (var character in Session.Query<Character>())
            {
                Session.Delete(character);
            }

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


            Session.Store(ox);
        }
    }
}