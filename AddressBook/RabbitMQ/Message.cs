using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json.Serialization;

namespace AddressBook.RabbitMQ
{
    public class Message : IMessage
    {
        public void SendMessage<AddressBookEntity>(AddressBookEntity entity)
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("Contact", true, false, false);

            var json = JsonConvert.SerializeObject(entity);
            var body = Encoding.UTF8.GetBytes(json);

            channel.BasicPublish(exchange: "", routingKey: "Contact", body: body);
        }
    }
}
