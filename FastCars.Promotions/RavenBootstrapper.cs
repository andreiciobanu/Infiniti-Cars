using NServiceBus;
using Raven.Client;
using Raven.Client.Document;

namespace InfinitiCars.Promotions
{
    public class RavenBootstrapper : INeedInitialization
    {
        public void Init()
        {
            Configure.Instance.Configurer.ConfigureComponent<IDocumentStore>(() =>
                {
                    var store = new DocumentStore
                    {
                        Url = "http://localhost:8082"
                    };

                    store.Initialize();
                    store.JsonRequestFactory.DisableRequestCompression = true;

                    return store;
                }, DependencyLifecycle.SingleInstance);

            Configure
                .Instance
                .Configurer
                .ConfigureComponent(() => Configure.Instance.Builder.Build<IDocumentStore>()
                .OpenSession(), DependencyLifecycle.InstancePerUnitOfWork);

            Configure
                .Instance
                .Configurer
                .ConfigureComponent<RavenUnitOfWork>(DependencyLifecycle.InstancePerUnitOfWork);
        }
    }
}
