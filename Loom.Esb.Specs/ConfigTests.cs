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
            var section = ConfigurationManager.GetSection(LoomEsbConfigurationSection.SectionName) as LoomEsbConfigurationSection;
            Assert.NotNull(section);
            Assert.NotNull(section.Actors);
            Assert.NotNull(section.Topics);
            Assert.AreEqual(3, section.Actors.Count);

            Assert.AreEqual(2, section.Topics.Count);
        }


        [Test]
        public void CanAddAnActor()
        {
            var actor = new ActorConfigurationElement("actorA");
            var section = new LoomEsbConfigurationSection();
            section.Actors.Add(actor);
            Assert.AreEqual(1, section.Actors.Count);
            Assert.AreEqual(actor, section.Actors.Cast<ActorConfigurationElement>().First());
        }

        [Test]
        public void CanAddAnotherActor()
        {     
            var actorB = new ActorConfigurationElement();
            actorB.Name = "actorB";
            var section = new LoomEsbConfigurationSection();
            section.Actors.Add(actorB);
        }

        [Test]
        public void CanAddATopic()
        {
            var greenTopic = new TopicConfigurationElement("green");
            var section = new LoomEsbConfigurationSection();
            section.Topics.Add(greenTopic);
            Assert.AreEqual(1, section.Topics.Count);
            Assert.AreEqual(greenTopic, section.Topics.Cast<TopicConfigurationElement>().First());
        }

        [Test]
        public void CanAddAnotherTopic()
        {
            var yellowTopic = new TopicConfigurationElement();
            yellowTopic.Name = "yellow";
            var section = new LoomEsbConfigurationSection();
            section.Topics.Add(yellowTopic);
        }

        [Test]
        public void CanAddASubscription()
        {
            var aFirstSubscription = new SubscriptionConfigurationElement("green");
            var actor = new ActorConfigurationElement("actor");
            actor.Subscriptions.Add(aFirstSubscription);
        }

        [Test]
        public void CanAddTwoSubscription()
        {
            var aSecondSubscription = new SubscriptionConfigurationElement();
            aSecondSubscription.Topic = "red";
            var actor = new ActorConfigurationElement("actor");
            actor.Subscriptions.Add(aSecondSubscription);
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
            var actor = new ActorConfigurationElement("actor");
            actor.Publications.Add(aFirstPublication);
        }

        [Test]
        public void CanAddAnotherPublication()
        {
            var aSecondPublication = new PublicationConfigurationElement();
            aSecondPublication.Topic = "red";
            var actor = new ActorConfigurationElement("actor");
            actor.Publications.Add(aSecondPublication);
        }

        [Test]
        public void CanAddAThirdPublication()
        {
            var topic = new TopicConfigurationElement("topic");
            var aThirdPublication = new PublicationConfigurationElement(topic);
            var actor = new ActorConfigurationElement("actor");
            actor.Publications.Add(aThirdPublication);
        }
    }
}
