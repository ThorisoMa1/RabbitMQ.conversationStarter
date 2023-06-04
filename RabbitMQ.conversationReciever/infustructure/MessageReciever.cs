using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.conversationReciever.interfaces;
using System.Text;

namespace RabbitMQ.conversationReciever.Infustructure
{
    internal class MessageReciever : IMessageReciever
    {

        private readonly IRabbitConfig _rabbitMQConfig;

        public MessageReciever(IRabbitConfig rabbitConifg) {

            _rabbitMQConfig = rabbitConifg;
        }  
        void IMessageReciever.RecieveMessages()
        {
            var conFactory = new ConnectionFactory()
            {
                HostName = _rabbitMQConfig.HostName,
                Port = _rabbitMQConfig.Port,
                UserName = _rabbitMQConfig.UserName,
                Password = _rabbitMQConfig.Password,
            };
      
            conFactory.ClientProvidedName = "RabbitMQ Conversation reciever";

            IConnection conn = conFactory.CreateConnection();
            
            IModel channel = conn.CreateModel();

            string exchangeName = "conversation-exchange";

            string routingKey = "conversation-routing-key";

            string queueName = "conversationQueue";

            channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);
            channel.QueueDeclare(queueName, false, false, false, null);
            channel.QueueBind(queueName, exchangeName, routingKey, null);
            channel.BasicQos(0,1,false);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (sender, args) =>
            {
                var messageBody = args.Body.ToArray();

                string recievedMesssage = Encoding.UTF8.GetString(messageBody);

                Console.WriteLine($"Message : ,{recievedMesssage}");
                Console.WriteLine("press a button to close this application ");

                // ackonolages that the message has been recieved
                channel.BasicAck(args.DeliveryTag,false);

            };

            string consumerTag = channel.BasicConsume(queueName, false, consumer);
            channel.BasicCancel(consumerTag);

            Console.ReadLine();

            channel.Close();
            conn.Close();

        }
    }
}
