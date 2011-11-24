namespace Loom.Esb
{
    using System.Collections.ObjectModel;

    public class Actor
    {
        private readonly string _name;
        private readonly ITransport _transport;
        private readonly MessageHandlerCollection _messageHandlers = new MessageHandlerCollection();

        public MessageHandlerCollection MessageHandlers
        {
            get { return _messageHandlers; }
        }

        public Actor(ITransport transport)
        {
            _transport = transport;
            Publications = new PublicationCollection();
            Subscriptions = new SubscriptionCollection();
        }

        public Actor(string name, ITransport transport)
            :this(transport)
        {
            _name = name;
        }

        public PublicationCollection Publications
        {
            get;
            private set;
        }

        public SubscriptionCollection Subscriptions { get; private set; }

        public void Connect()
        {
        }

        public void Publish(object message)
        {
            _transport.Send(message);
        }
    }

    public interface IMessageHandler
    {
    }

    public interface IMessageHandler<T> : IMessageHandler
    {
        void Handle(T message);
    }

    public class MessageHandlerCollection : Collection<IMessageHandler>
    {
    }
}
