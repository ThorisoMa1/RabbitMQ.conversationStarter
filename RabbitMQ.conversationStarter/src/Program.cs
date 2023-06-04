using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Logging;
using RabbitMQ.conversationStarter;
using RabbitMQ.conversationStarter.Infustructure;
using RabbitMQ.conversationStarter.Interfaces;
using System;
using System.Text;


// Configure the service provider
var serviceProvider = startup.ConfigureServices();

// Resolve and use your dependencies
var messageSendingService = serviceProvider.GetService<IMessageSenderService>();



Console.WriteLine("please enter your name and surname for the greeting and press enter ");
string name = Console.ReadLine();

string message = string.Format("Hello My name is {0}", name);

Console.WriteLine("thank you , sending your message.......");

// send the message 
messageSendingService.SendMessage(message);

Console.WriteLine("SENT");










