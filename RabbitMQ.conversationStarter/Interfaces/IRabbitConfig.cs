

namespace RabbitMQ.conversationStarter.Interfaces
{
    internal interface IRabbitConfig
    {
        string HostName { get; }
        int Port { get; }
        string UserName { get; }
        string Password { get; }

    }
}
