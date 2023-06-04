using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.conversationReciever.application;
using RabbitMQ.conversationReciever.Infustructure;
using RabbitMQ.conversationReciever.interfaces;
namespace RabbitMQ.conversationReciever
{
    internal class startup
    {
        public static IServiceProvider ConfigureServices()
        { 
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json")
                                                                            .Build();
            var serviceProvider = new ServiceCollection()
                    .AddSingleton<IConfiguration>(configuration)
                    .AddSingleton<IMessageReciever, MessageReciever>()
                    .AddSingleton<IMessageRecieverService, MessageRecieverService>()
                    .AddSingleton<IRabbitConfig, RabbitConfig>()
                    // Register other dependencies
                    .BuildServiceProvider();

            return serviceProvider;
        }

    }
}
