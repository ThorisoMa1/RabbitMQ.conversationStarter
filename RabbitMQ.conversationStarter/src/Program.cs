using RabbitMQ.Client;
using System.Text;

ConnectionFactory conFactory = new ConnectionFactory();

conFactory.Uri = new Uri("amqp://guest:guest@localhost:15672");
conFactory.ClientProvidedName = "RabbitMQ Conversation Starter";


IConnection conn = conFactory.CreateConnection();
IModel channel = conn.CreateModel();

string exchangeName="demo-exchange";

string routingKey = "demo-routing-key";

string queueName = "DemoQueue";



channel.ExchangeDeclare(exchangeName,ExchangeType.Direct);
channel.QueueDeclare(queueName,false,false,false,null);
channel.QueueBind(queueName,exchangeName,routingKey,null);

byte[] messageBodyBytes = Encoding.UTF8.GetBytes("Hi There , lets start a conversation");

channel.BasicPublish(exchangeName,routingKey,null,messageBodyBytes);

channel.Close();
conn.Close();





