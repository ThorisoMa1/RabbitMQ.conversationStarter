

using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.conversationReciever;
using RabbitMQ.conversationReciever.interfaces;

// Configure the service provider
var serviceProvider = startup.ConfigureServices();

// Resolve and use your dependencies
var messageRecievingService = serviceProvider.GetService<IMessageRecieverService>();

Console.WriteLine("listeing for messages..");

// send the message 
messageRecievingService.RecieveMessages();
