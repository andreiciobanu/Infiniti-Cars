using System;
using InfinitiCars.Events;
using NServiceBus;

namespace InfinitiCars.Promotions
{
    public class ClientBecamePreferredHandler : IHandleMessages<ClientBecamePreferred>
    {
        public void Handle(ClientBecamePreferred message)
        {
            Console.WriteLine("Client became preferred, send them a new free rental offer");
        }
    }
}
