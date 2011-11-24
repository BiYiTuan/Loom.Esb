namespace Loom.Esb
{
    using System;
    using System.Messaging;

    public class MsmqTransport : ITransport, IDisposable
    {
        private readonly MessageQueue _messageQueue;

        public event EventHandler<MessageReceivedEventArgs> MessageReceived = delegate { };  

        public MsmqTransport()
        {
            _messageQueue = new MessageQueue(".\\private$\\TestQueue");
            _messageQueue.PeekCompleted += OnMessagePeeked;
            _messageQueue.BeginPeek();
            
        }

        private void OnMessagePeeked(object sender, PeekCompletedEventArgs e)
        {
            var transaction = new MessageQueueTransaction();
            try
            {
                transaction.Begin();
                var message = _messageQueue.Receive(transaction);
                MessageReceived(this, new MessageReceivedEventArgs(message));
            }
            catch
            {
                transaction.Abort();
                throw;
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public void Send(object message)
        {
            var transaction = new MessageQueueTransaction();
            try
            {
                transaction.Begin();
                _messageQueue.Send(message, transaction);
                transaction.Commit();
            }
            catch
            {
                transaction.Abort();
                throw;
            }
            finally
            {
                transaction.Dispose();
            }
        }

        public void Dispose()
        {
            _messageQueue.Dispose();
        }
    }
}