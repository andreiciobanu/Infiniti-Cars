using NServiceBus;

namespace InfinitiCars.Common
{
    public class UnobtrusiveConventions : IWantToRunBeforeConfiguration
    {
        public void Init()
        {
            Configure
                .Instance
                .DefiningEventsAs(t => t.Namespace != null && t.Namespace.StartsWith("InfinitiCars")
                                                          && t.Namespace.EndsWith("Events"));
        }
    }
}
