using System.Web.Http;
using BetrayalAPI.Models;

namespace BetrayalAPI.Controllers
{
    public class BetrayalController : RavenController
    {
        [HttpGet]
        public Character GetCharacter()
        {
            var character = new Character
                            {
                                Name = "Colm"
                            };

            Session.Store(character);
            return character;
        }
    }
}
