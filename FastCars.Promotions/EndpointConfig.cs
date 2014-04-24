using NServiceBus;

namespace InfinitiCars.Promotions
{
    public class EndpointConfig : IConfigureThisEndpoint, AsA_Server, UsingTransport<NServiceBus.RabbitMQ>
    {
    }
}
