namespace Loom.Esb
{
    public class Message
    {
        public object Body { get; private set; }
        
        public string BodyAsString
        {
            get { return (string) Body; }
        }

        public Message(object body)
        {
            Body = body;
        }
    }
}