using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.conversationStarter.Application;
using RabbitMQ.conversationStarter.Infustructure;
using RabbitMQ.conversationStarter.Interfaces;

namespace RabbitMQ.conversationStarter
{
    internal class startup
    {
        public static IServiceProvider ConfigureServices()
        { 
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                                                            .Build();
            var serviceProvider = new ServiceCollection()
                    .AddSingleton<IConfiguration>(configuration)
                    .AddSingleton<IMessageSender, MessageSender>()
                    .AddSingleton<IMessageSenderService, MessageSenderService>()
                    .AddSingleton<IRabbitConfig, RabbitConfig>()
                    // Register other dependencies
                    .BuildServiceProvider();

            return serviceProvider;
        }

    }
}
