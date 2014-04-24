using InfinitiCars.App_Start;
using InfinitiCars.DI;
using InfinitiCars.RavenDB;
using NServiceBus;
using NServiceBus.Installation.Environments;
using Raven.Client.Document;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace InfinitiCars
{
    public class WebApiApplication : HttpApplication
    {
        public static IBus Bus;

        public static DocumentStore Store;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //ConfigureNServiceBus();

            RavenDBInit();
        }

        private void ConfigureNServiceBus()
        {
            Bus = Configure.With()
                     .DefaultBuilder()
                     .ForWebApi()
                     .UseTransport<NServiceBus.RabbitMQ>()
                     .PurgeOnStartup(true)
                     .UnicastBus()
                     .CreateBus()
                     .Start(() => Configure
                                    .Instance
                                    .ForInstallationOn<Windows>()
                                    .Install());

        }

        private void RavenDBInit()
        {
            Store = new DocumentStore
            {
                Url = "http://localhost:8082",
                DefaultDatabase = "InfinitiCars"
            };

            Store.RegisterListener(new StoreListener());
            Store.RegisterListener(new UserVersion1ToVersion2Converter());

            Store.Initialize();
        }
    }
}
