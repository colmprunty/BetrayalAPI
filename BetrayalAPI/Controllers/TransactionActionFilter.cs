using System.Web.Http.Filters;
using Raven.Client;

namespace BetrayalAPI.Controllers
{
    public class TransactionActionFilter : ActionFilterAttribute
    {
        public IDocumentSession RavenSession { get; set; }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            using (RavenSession)
            {
                if (actionExecutedContext.Exception != null)
                    return;

                if (RavenSession != null)
                    RavenSession.SaveChanges();
            }
        }
    }
}