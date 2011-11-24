namespace Loom.Esb.Specs
{
    using System.Threading;
    using NUnit.Framework;

    [TestFixture]
    public class MsmqTransportTests
    {
        [Test]
        public void Foo()
        {
            using (var transport = new MsmqTransport())
            {
                ManualResetEvent mre = new ManualResetEvent(false);
                transport.MessageReceived += (sender, e) => { mre.Set(); };

                transport.Send("hello");

                mre.WaitOne();
            }
        }
    }
}