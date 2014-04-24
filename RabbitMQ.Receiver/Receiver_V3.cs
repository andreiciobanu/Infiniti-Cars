using System;
using System.Text;
using RabbitMQ.Client;

namespace RabbitMQ.Receiver
{
    public class ReceiveLogs
    {
        public static void Main()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare("logs", "fanout");

                    var queueName = channel.QueueDeclare();

                    channel.QueueBind(queueName, "logs", "");

                    var consumer = new QueueingBasicConsumer(channel);

                    channel.BasicConsume(queueName, true, consumer);

                    Console.WriteLine(" [*] Waiting for logs." +
                                      "To exit press CTRL+C");
                    while (true)
                    {
                        var ea = consumer.Queue.Dequeue();

                        var body = ea.Body;

                        var message = Encoding.UTF8.GetString(body);

                        Console.WriteLine(" [x] {0}", message);
                    }
                }
            }
        }
    }
}
