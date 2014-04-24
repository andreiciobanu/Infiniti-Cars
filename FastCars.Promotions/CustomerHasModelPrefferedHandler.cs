using System;
using InfinitiCars.Events;
using NServiceBus;

namespace InfinitiCars.Promotions
{
    public class CustomerHasModelPrefferedHandler : IHandleMessages<CustomerHasModelPreffered>
    {
        public void Handle(CustomerHasModelPreffered message)
        {
            Console.WriteLine("The customer has a preffered model");

            // ToDo :save the model into the list of the customer list of preffered manufacturer
        }
    }
}