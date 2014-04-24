using System;
using RabbitMQ.Client;
using System.Text;
using System.Threading;

namespace RabbitMQ.Receiver
{
    public class Worker
    {
        public static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare("task_queue", true, false, false, null);

                    //RabbitMQ just dispatches a message when the message enters the queue. It doesn't look at the number of unacknowledged messages 
                    //for a consumer. It just blindly dispatches every n-th message to the n-th consumer
                    //In order to defeat that we can use the basicQos method with the prefetchCount = 1 setting. This tells RabbitMQ not to 
                    //give more than one message to a worker at a time. Or, in other words, don't dispatch a new message to a worker until it 
                    //has processed and acknowledged the previous one. Instead, it will dispatch it to the next worker that is not still busy.

                    //In order to make sure a message is never lost, RabbitMQ supports message acknowledgments. An ack(nowledgement) is sent back from
                    //the consumer to tell RabbitMQ that a particular message has been received, processed and that RabbitMQ is free to delete it.
                    channel.BasicQos(0, 1, false);

                    var consumer = new QueueingBasicConsumer(channel);

                    channel.BasicConsume("task_queue", false, consumer);

                    Console.WriteLine(" [*] Waiting for messages. " +
                                      "To exit press CTRL+C");
                    while (true)
                    {
                        var ea = consumer.Queue.Dequeue();

                        var body = ea.Body;

                        var message = Encoding.UTF8.GetString(body);

                        Console.WriteLine(" [x] Received {0}", message);

                        int dots = message.Split('.').Length - 1;

                        Thread.Sleep(dots * 1000);

                        Console.WriteLine(" [x] Done");

                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                }
            }
        }
    }
}
