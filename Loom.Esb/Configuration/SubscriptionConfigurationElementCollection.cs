namespace Loom.Esb.Configuration
{
    using System.Configuration;

    public class SubscriptionConfigurationElementCollection : ConfigurationElementCollection
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
    }
}