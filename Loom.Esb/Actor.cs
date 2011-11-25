namespace Loom.Esb
{
    public class Actor
    {
        private readonly string _name;
        private readonly MessageHandlerCollection _messageHandlers = new MessageHandlerCollection();

        public MessageHandlerCollection MessageHandlers
        {
            get { return _messageHandlers; }
        }

        public Actor()
        {
        }

        public Actor(string name)
        {
            _name = name;
            Publications = new PublicationCollection();
            Subscriptions = new SubscriptionCollection();
        }

        public PublicationCollection Publications { get; private set; }

        public SubscriptionCollection Subscriptions { get; private set; }

        public void Connect()
        {
        }

        public void Publish(string topic, object message)
        {
        }
    }
}
