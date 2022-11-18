using System;
using System.Text.Json.Serialization;
using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;

namespace AddressBookReceiver
{
    public class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("Contact", true, false, false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"New Contact Has Been Added To Address Book \n {message}");
            };

            channel.BasicConsume(queue: "Contact", autoAck: true, consumer: consumer);
            Console.ReadLine();
        }
    }
}
