namespace Loom.Esb.Configuration
{
    using System.Collections.Generic;
    using System.Configuration;

    public class SubscriptionConfigurationElementCollection : ConfigurationElementCollection, IEnumerable<SubscriptionConfigurationElement>
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new SubscriptionConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((SubscriptionConfigurationElement) element).Topic;
        }

        public void Add(SubscriptionConfigurationElement subscription)
        {
            BaseAdd(subscription);
        }

        public new IEnumerator<SubscriptionConfigurationElement> GetEnumerator()
        {
            for(var i = 0; i < Count; i++)
            {
                yield return BaseGet(i) as SubscriptionConfigurationElement;
            }
        }
    }
}