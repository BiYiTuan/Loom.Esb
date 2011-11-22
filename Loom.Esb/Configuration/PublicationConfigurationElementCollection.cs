namespace Loom.Esb.Configuration
{
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;

    public class PublicationConfigurationElementCollection : ConfigurationElementCollection, IEnumerable<PublicationConfigurationElement>
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

        public new IEnumerator<PublicationConfigurationElement> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
                yield return BaseGet(i) as PublicationConfigurationElement;
        }
    }
}