using RabbitMQ.Client;
using RabbitMQ.conversationStarter.Interfaces;
using System.Text;

namespace RabbitMQ.conversationStarter.Infustructure
{
    internal class MessageSender : IMessageSender
    {

        private readonly IRabbitConfig _rabbitMQConfig;

        public MessageSender(IRabbitConfig rabbitConifg) {

            _rabbitMQConfig = rabbitConifg;
        }  
        void IMessageSender.SendMessage(string message)
        {
            var conFactory = new ConnectionFactory()
            {
                HostName = _rabbitMQConfig.HostName,
                Port = _rabbitMQConfig.Port,
                UserName = _rabbitMQConfig.UserName,
                Password = _rabbitMQConfig.Password,
            };

            // conFactory.Uri = new Uri("amqp://guest:guest@localhost:5672");
            
            conFactory.ClientProvidedName = "RabbitMQ Conversation Starter";

            IConnection conn = conFactory.CreateConnection();
            
            IModel channel = conn.CreateModel();

            string exchangeName = "conversation-exchange";

            string routingKey = "conversation-routing-key";

            string queueName = "conversationQueue";

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey, null);

            byte[] messageBodyBytes = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchangeName, routingKey, null, messageBodyBytes);

            channel.Close();
            conn.Close();

        }
    }
}
