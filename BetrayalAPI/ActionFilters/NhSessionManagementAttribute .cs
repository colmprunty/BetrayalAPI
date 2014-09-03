using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using NHibernate;
using NHibernate.Context;

namespace BetrayalAPI.ActionFilters
{
    public class NhSessionManagementAttribute : ActionFilterAttribute
    {
        private ISessionFactory SessionFactory { get; set; }

        public NhSessionManagementAttribute()
        {
            SessionFactory = WebApiApplication.SessionFactory;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var session = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
            session.BeginTransaction();
        }
        
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            if(!CurrentSessionContext.HasBind(SessionFactory))
                return;

            var session = SessionFactory.GetCurrentSession();
            var transaction = session.Transaction;
            if (transaction != null && transaction.IsActive)
                transaction.Commit();
            
            session = CurrentSessionContext.Unbind(SessionFactory);
            session.Close();
        }
    }
}