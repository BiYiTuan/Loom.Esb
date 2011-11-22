namespace Loom.Esb.Specs
{
    using System.Configuration;
    using System.Linq;
    using NUnit.Framework;

    using Configuration;

    [TestFixture]
    public class ConfigTests
    {
        [Test]
        public void CanReadConfigSection()
        {
            var section = ConfigurationManager.GetSection("loom.esb") as LoomEsbConfigurationSection;
            Assert.NotNull(section);
            Assert.NotNull(section.Actors);
            Assert.NotNull(section.Topics);
            Assert.AreEqual(3, section.Actors.Count);

            Assert.AreEqual(2, section.Topics.Count);
        }

        private LoomEsbConfigurationSection _section;
        private ActorConfigurationElement _actorA;
        private TopicConfigurationElement _yellowTopic;

        [SetUp]
        public void Setup()
        {
            _section = new LoomEsbConfigurationSection();
        }

        [Test]
        public void CanAddAnActor()
        {
            _actorA = new ActorConfigurationElement("actorA");

            _section.Actors.Add(_actorA);
            Assert.AreEqual(1, _section.Actors.Count);
            Assert.AreEqual(_actorA, _section.Actors.Cast<ActorConfigurationElement>().First());
        }

        [Test]
        public void CanAddAnotherActor()
        {     
            var actorB = new ActorConfigurationElement();
            actorB.Name = "actorB";
            _section.Actors.Add(actorB);
        }

        [Test]
        public void CanAddATopic()
        {
            var greenTopic = new TopicConfigurationElement("green");
            _section.Topics.Add(greenTopic);
            Assert.AreEqual(1, _section.Topics.Count);
            Assert.AreEqual(greenTopic, _section.Topics.Cast<TopicConfigurationElement>().First());
        }

        [Test]
        public void CanAddAnotherTopic()
        {
            _yellowTopic = new TopicConfigurationElement();
            _yellowTopic.Name = "yellow";
            _section.Topics.Add(_yellowTopic);
        }

        [Test]
        public void CanAddASubscription()
        {
            var aFirstSubscription = new SubscriptionConfigurationElement("green");
            _actorA.Subscriptions.Add(aFirstSubscription);
        }

        [Test]
        public void CanAddAnotherSubscription()
        {
            var aSecondSubscription = new SubscriptionConfigurationElement();
            aSecondSubscription.Topic = "red";
            _actorA.Subscriptions.Add(aSecondSubscription);
         }

        [Test]
        public void CanAddAThirdSubscription()
        {
            var aThirdSubscription = new SubscriptionConfigurationElement(new TopicConfigurationElement("yellow"));
            var actor = new ActorConfigurationElement("a");
            actor.Subscriptions.Add(aThirdSubscription);
        }

        [Test]
        public void CanAddAPublication()
        {
            var aFirstPublication = new PublicationConfigurationElement("green");
            _actorA.Publications.Add(aFirstPublication);
        }

        [Test]
        public void CanAddAnotherPublication()
        {
            var aSecondPublication = new PublicationConfigurationElement();
            aSecondPublication.Topic = "red";
            _actorA.Publications.Add(aSecondPublication);
        }

        [Test]
        public void CanAddAThirdPublication()
        {
            var aThirdPublication = new PublicationConfigurationElement(_yellowTopic);
            _actorA.Publications.Add(aThirdPublication);
        }
    }
}
