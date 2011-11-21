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

        [Test]
        public void CanCreateSection()
        {
            var section = new LoomEsbConfigurationSection();
            var actorA = new ActorConfigurationElement("actorA");

            section.Actors.Add(actorA);
            Assert.AreEqual(1, section.Actors.Count);
            Assert.AreEqual(actorA, section.Actors.Cast<ActorConfigurationElement>().First());

            var actorB = new ActorConfigurationElement();
            actorB.Name = "actorB";
            section.Actors.Add(actorB);

            var greenTopic = new TopicConfigurationElement("green");
            section.Topics.Add(greenTopic);
            Assert.AreEqual(1, section.Topics.Count);
            Assert.AreEqual(greenTopic, section.Topics.Cast<TopicConfigurationElement>().First());

            var yellowTopic = new TopicConfigurationElement();
            yellowTopic.Name = "yellow";
            section.Topics.Add(yellowTopic);

            var aFirstSubscription = new SubscriptionConfigurationElement("green");
            actorA.Subscriptions.Add(aFirstSubscription);

            var aSecondSubscription = new SubscriptionConfigurationElement();
            aSecondSubscription.Topic = "red";
            actorA.Subscriptions.Add(aSecondSubscription);

            var aThirdSubscription = new SubscriptionConfigurationElement(yellowTopic);
            actorA.Subscriptions.Add(aThirdSubscription);

            var aFirstPublication = new PublicationConfigurationElement("green");
            actorA.Publications.Add(aFirstPublication);

            var aSecondPublication = new PublicationConfigurationElement();
            aSecondPublication.Topic = "red";
            actorA.Publications.Add(aSecondPublication);

            var aThirdPublication = new PublicationConfigurationElement(yellowTopic);
            actorA.Publications.Add(aThirdPublication);
        }
    }
}
