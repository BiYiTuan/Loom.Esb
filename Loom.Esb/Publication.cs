namespace Loom.Esb
{
    public class Publication
    {
        private readonly IPublicationTransport _transport;

        public string Topic { get; private set; }

        public Publication(string topic, IPublicationTransport transport)
        {
            _transport = transport;
            Topic = topic;
        }
    }
}