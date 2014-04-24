using Core.Domain;
using InfinitiCars.Events;
using Raven.Client.Listeners;
using Raven.Json.Linq;

namespace InfinitiCars.RavenDB
{
    public class StoreListener : IDocumentStoreListener
    {
        public void AfterStore(string key, object entityInstance, RavenJObject metadata)
        {

        }

        public bool BeforeStore(string key, object entityInstance, RavenJObject metadata, RavenJObject original)
        {
            var user = entityInstance as User;

            if (user == null)
            {
                return false;
            }

            //Send NServiceBus message
            var newModel = new NewModelAppeared { Make = "" };

            WebApiApplication.Bus.Send(newModel);

            return true;
        }
    }
}