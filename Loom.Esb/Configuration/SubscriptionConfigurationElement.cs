namespace Loom.Esb.Configuration
{
    using System.Configuration;

    public class SubscriptionConfigurationElement : ConfigurationElement
    {
        public const string TopicPropertyName = "topic";

        public SubscriptionConfigurationElement()
        {
            
        }

        public SubscriptionConfigurationElement(string topic)
        {
            Topic = topic;
        }

        public SubscriptionConfigurationElement(TopicConfigurationElement topicConfigurationElement)
        {
            Topic = topicConfigurationElement.Name;
        }

        [ConfigurationProperty(TopicPropertyName, IsKey = true)]
        public string Topic
        {
            get { return base["topic"] as string; }
            set { base["topic"] = value; }
        }
    }
}