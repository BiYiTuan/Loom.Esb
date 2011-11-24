namespace Loom.Esb
{
    using System;

    public interface ITransport
    {
        void Send(object message);
        event EventHandler<MessageReceivedEventArgs> MessageReceived;
    }
}