namespace Loom.Esb
{
    public class Actor
    {
        private readonly string _name;

        public Actor()
        {
            Publications = new PublicationCollection();
            Subscriptions = new SubscriptionCollection();
        }

        public Actor(string name)
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
    }
}
