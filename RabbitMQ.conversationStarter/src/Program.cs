using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.conversationStarter;
using RabbitMQ.conversationStarter.Infustructure;
using RabbitMQ.conversationStarter.Interfaces;
using System;
using System.Text;


// Configure the service provider
var serviceProvider = startup.ConfigureServices();


// Resolve and use your dependencies
var messageSendingService = serviceProvider.GetService<IMessageSenderService>();


messageSendingService.SendMessage("Hello, RabbitMQ!");








