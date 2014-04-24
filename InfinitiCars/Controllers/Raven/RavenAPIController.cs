using System.Web.Http;
using System.Web.Http.Controllers;
using Raven.Client;

namespace InfinitiCars.Controllers.Raven
{
    public class RavenAPIController : ApiController
    {
        public IDocumentSession Session { get; set; }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);

            if (Session == null)
            {
                Session = WebApiApplication.Store.OpenSession();
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            using (Session)
            {
                if (Session != null)
                {
                    Session.SaveChanges();
                }
            }
        }
    }
}