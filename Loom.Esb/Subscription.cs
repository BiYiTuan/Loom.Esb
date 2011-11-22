namespace Loom.Esb
{
    public class Subscription
    {
        public string Topic { get; set; }

        public Subscription(string topic)
        {
            Topic = topic;
        }
    }
}