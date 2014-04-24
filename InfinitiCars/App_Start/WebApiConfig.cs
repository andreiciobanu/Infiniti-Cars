using System.Web.Http;

namespace InfinitiCars.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                  name: "Custom",
                  routeTemplate: "api/{controller}/{action}/{id}",
                  defaults: new { action = "get", id = RouteParameter.Optional });
        }
    }
}
