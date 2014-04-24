using Raven.Client;
using System.Web.Mvc;

namespace InfinitiCars.Controllers.Raven
{
    public class RavenController : Controller
    {
        public IDocumentSession RavenSession { get; protected set; }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.IsChildAction)
                return;

            using (RavenSession)
            {
                if (filterContext.Exception != null)
                    return;

                if (RavenSession != null)
                {
                    RavenSession.SaveChanges();
                }
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (RavenSession == null)
            {
                RavenSession = WebApiApplication.Store.OpenSession();
            }
        }
    }
}