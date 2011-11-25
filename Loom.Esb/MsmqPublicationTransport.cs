namespace Loom.Esb
{
    using System.Messaging;
    using System.Transactions;

    public class MsmqPublicationTransport : IPublicationTransport
    {
        public void Send(Message message)
        {
            using (var tx = new TransactionScope(TransactionScopeOption.Required))
            {
                _messageQueue.Send(message, MessageQueueTransactionType.Automatic);
                tx.Complete();
            }

        }
    }
}