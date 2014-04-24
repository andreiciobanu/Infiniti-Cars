using System;
using Core.Domain;
using InfinitiCars.Events;
using NServiceBus;
using Raven.Client;

namespace InfinitiCars.Promotions
{
    public class NewModelAppearedHandler : IHandleMessages<NewModelAppeared>
    {
        public IDocumentSession Session { get; set; }

        public void Handle(NewModelAppeared message)
        {
            Session.Store(new Model
                {
                    Name = message.Model,
                    Id = Guid.NewGuid()
                });

            Console.WriteLine("The manufacturer has released a new model.");
        }
    }
}