namespace Loom.Esb
{
    public class Publication
    {
        public string Topic { get; private set; }

        public Publication(string topic)
        {
            Topic = topic;
        }
    }
}