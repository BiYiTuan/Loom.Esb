namespace Loom.Esb
{
    using System;
    using System.Messaging;

    public class MessageReceivedEventArgs : EventArgs
    {
        public Message Message { get; private set; }

        public MessageReceivedEventArgs(Message message)
        {
            Message = message;
        }
    }
}