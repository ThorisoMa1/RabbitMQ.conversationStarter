using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
