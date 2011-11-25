namespace Loom.Esb
{
    using System;

    public interface ISubscriptionTransport
    {
        void WhenMessageArives(Action<Message> messageHandler);
    }
}