using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.conversationStarter.Interfaces;
using System.Text;



ConnectionFactory conFactory = new ConnectionFactory();

conFactory.Uri = new Uri("amqp://guest:guest@localhost:5672");
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


 void intialiseSettings() 
{

    var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                                                            .Build();
    var serviceProvider = new ServiceCollection()
            .AddSingleton<IConfiguration>(configuration)
            .AddSingleton<IRabbitConfig>()
            // Register other dependencies
            .BuildServiceProvider();


    var rabbitMQConfig = serviceProvider.GetService<IRabbitConfig>();


}







