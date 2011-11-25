namespace Loom.Esb
{
    using System;

    public class MessageReceivedEventArgs : EventArgs
    {
        public object Message { get; private set; }

        public MessageReceivedEventArgs(object message)
        {
            Message = message;
        }
    }
}