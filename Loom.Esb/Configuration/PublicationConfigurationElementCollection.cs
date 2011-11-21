namespace Loom.Esb.Configuration
{
    using System.Configuration;

    public class PublicationConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new PublicationConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((PublicationConfigurationElement)element).Topic;
        }

        public void Add(PublicationConfigurationElement publication)
        {
            BaseAdd(publication);
        }
    }
}