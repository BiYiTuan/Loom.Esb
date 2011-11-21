namespace Loom.Esb.Configuration
{
    using System.Configuration;

    public class PublicationConfigurationElement : ConfigurationElement
    {
        private const string TopicPropertyName = "topic";

        public PublicationConfigurationElement()
        {
            
        }

        public PublicationConfigurationElement(string topic)
        {
            Topic = topic;
        }

        public PublicationConfigurationElement(TopicConfigurationElement topicConfigurationElement)
        {
            Topic = topicConfigurationElement.Name;
        }

        [ConfigurationProperty(TopicPropertyName, IsKey = true)]
        public string Topic
        {
            get { return base[TopicPropertyName] as string; }
            set { base[TopicPropertyName] = value; }
        }
    }
}