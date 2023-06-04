using RabbitMQ.conversationStarter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.conversationStarter.Application
{
    public class MessageSenderService : IMessageSenderService
    {
        private readonly IMessageSender _messageSender;

        public MessageSenderService(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        void IMessageSenderService.SendMessage(string message)
        {
            _messageSender.SendMessage(message);
        }
    }
}
