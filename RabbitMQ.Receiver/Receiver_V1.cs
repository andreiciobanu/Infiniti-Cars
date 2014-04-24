using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ.Receiver
{
    public class Receive
    {
        public static void Main()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("hello", false, false, false, null);

                    //We're about to tell the server to deliver us the messages from the queue. 
                    //Since it will push us messages asynchronously, we provide a callback in the form of an object that will buffer the messages
                    //until we're ready to use them. That is what QueueingBasicConsumer does.
                    var consumer = new QueueingBasicConsumer(channel);

                    channel.BasicConsume("hello", true, consumer);

                    Console.WriteLine(" [*] Waiting for messages." +
                                             "To exit press CTRL+C");
                    while (true)
                    {
                        var ea = consumer.Queue.Dequeue();

                        var body = ea.Body;
                        var message = Encoding.UTF8.GetString(body);

                        Console.WriteLine(" [x] Received {0}", message);
                    }
                }
            }
        }
    }
}
