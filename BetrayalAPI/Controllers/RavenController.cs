using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using Raven.Client;

namespace BetrayalAPI.Controllers
{
    [EnableCors(origins: "http://localhost:5454", headers: "*", methods: "*")]
    public class RavenController : ApiController
    {
        public IDocumentSession Session { get; set; }

        public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            Session = WebApiConfig.DocumentStore.OpenSession();
            return base.ExecuteAsync(controllerContext, cancellationToken)
                .ContinueWith(task =>
                              {
                                  using (Session)
                                  {
                                      if (task.Status != TaskStatus.Faulted && Session != null)
                                          Session.SaveChanges();
                                  }
                                  return task;
                              }).Unwrap();
        }
    }
}
