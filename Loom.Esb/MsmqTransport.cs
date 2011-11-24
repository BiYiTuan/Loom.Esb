namespace Loom.Esb
{
    using System;
    using System.Messaging;
    using System.Transactions;

    public class MsmqTransport : ITransport, IDisposable
    {
        private readonly MessageQueue _messageQueue;

        public event EventHandler<MessageReceivedEventArgs> MessageReceived = delegate { };  

        public MsmqTransport()
        {
            _messageQueue = new MessageQueue(".\\private$\\TestQueue");
            _messageQueue.ReceiveCompleted += OnMessageReceived;
            _messageQueue.BeginReceive();
        }

        private void OnMessageReceived(object sender, ReceiveCompletedEventArgs e)
        {
            MessageReceived(this, new MessageReceivedEventArgs(e.Message));
        }

        public void Send(object message)
        {
            using (var tx = new TransactionScope(TransactionScopeOption.Required))
            {
                _messageQueue.Send(message);
                tx.Complete();
            }
        }

        public void Dispose()
        {
            _messageQueue.Dispose();
        }
    }
}