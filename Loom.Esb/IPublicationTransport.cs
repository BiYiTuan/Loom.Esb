namespace Loom.Esb
{
    public interface IPublicationTransport
    {
        void Send(object message);
    }
}