using Microsoft.Extensions.Configuration;
using RabbitMQ.conversationReciever.interfaces;

namespace RabbitMQ.conversationReciever.Infustructure
{
    internal class RabbitConfig : IRabbitConfig
    {

        private readonly IConfiguration _configuration;

        public string HostName => _configuration["RabbitMQ:HostName"];
        public int Port => int.Parse(_configuration["RabbitMQ:Port"]);
        public string UserName => _configuration["RabbitMQ:UserName"];
        public string Password => _configuration["RabbitMQ:Password"];

        public RabbitConfig(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
