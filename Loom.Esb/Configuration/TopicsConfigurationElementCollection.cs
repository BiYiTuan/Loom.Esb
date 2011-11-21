namespace Loom.Esb.Configuration
{
    using System.Configuration;

    public class TopicsConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new TopicConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((TopicConfigurationElement) element).Name;
        }

        public void Add(TopicConfigurationElement topic)
        {
            BaseAdd(topic);
        }
    }
}