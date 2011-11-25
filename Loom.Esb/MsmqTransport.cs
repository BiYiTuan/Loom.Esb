namespace Loom.Esb
{
    using System;
    using System.Collections.Generic;
    using System.Messaging;
    using System.Transactions;

    using MsmqMessage = System.Messaging.Message;

    public class MsmqSubscriptionTransport : ISubscriptionTransport, IDisposable
    {
        private readonly MessageQueue _messageQueue;
        private Action<Message> _whenMessageArrives;

        public event EventHandler<MessageReceivedEventArgs> MessageReceived = delegate { };

        public MsmqSubscriptionTransport(string topic, string actor, MsmqTransportConfiguration transportConfiguration)
        {
            _messageQueue = new MessageQueue();
            if (transportConfiguration.ConventionBasedNaming)
            {
                if (transportConfiguration.Delivery == DeliveryMethod.Brokered)
                {

                }
            }

            
            _messageQueue.PeekCompleted += OnMessagePeeked;
            _messageQueue.BeginPeek();
        }

        private void OnMessagePeeked(object sender, PeekCompletedEventArgs e)
        {
            using (var tx = new TransactionScope(TransactionScopeOption.Required))
            {
                var message = _messageQueue.Receive(MessageQueueTransactionType.Automatic);
                if (message != null)
                {
                    _whenMessageArrives(new Message(message.Body));
                    tx.Complete();
                }
            }
        }


        public void Dispose()
        {
            _messageQueue.Dispose();
        }

        public void WhenMessageArives(Action<Message> whenMessageArrives)
        {
            _whenMessageArrives = whenMessageArrives;
        }
    }

    public class MsmqTransportConfiguration
    {
        public string DefaultServer { get; set; }
        public bool ConventionBasedNaming { get; set; }
        public DeliveryMethod Delivery { get; set; }
        public Dictionary<string, string> Mappings { get; set; }

        public MsmqTransportConfiguration()
        {
            Mappings = new Dictionary<string, string>();
        }
    }
}