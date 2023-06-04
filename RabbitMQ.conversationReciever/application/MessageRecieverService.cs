using RabbitMQ.conversationReciever.interfaces;

namespace RabbitMQ.conversationReciever.application
{
    internal class MessageRecieverService : IMessageRecieverService
    {
        private readonly IMessageReciever _messageReciever;

        public MessageRecieverService(IMessageReciever messageSender)
        {
            _messageReciever = messageSender;
        }

        void IMessageRecieverService.RecieveMessages()
        {
            _messageReciever.RecieveMessages();
        }
    }
}
