namespace Loom.Esb.Specs
{
    using System.Threading;
    using NUnit.Framework;

    [TestFixture]
    public class MsmqTransportTests
    {
        [Test]
        public void CanSendAndReceiveMessageOnSameQueue()
        {
            //using (var transport = new MsmqTransport("", "", new MsmqTransportConfiguration())) // ".\\private$\\TestQueue"
            //{
            //    var mre = new ManualResetEvent(false);
            //    object receivedMessage = null;
            //    transport.MessageReceived += (sender, e) =>
            //                                     {
            //                                         receivedMessage = e.Message;
            //                                         mre.Set();
            //                                     };

            //    transport.Send("hello");

            //    mre.WaitOne();

            //    Assert.IsNotNull(receivedMessage);
            //    Assert.AreEqual("hello", receivedMessage);
            //}
        }
    }
}