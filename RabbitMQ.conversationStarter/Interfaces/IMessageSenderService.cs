using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RabbitMQ.conversationStarter.Interfaces
{
    internal interface IMessageSenderService 
    {
        public void SendMessage(string message);
 
    }
}
