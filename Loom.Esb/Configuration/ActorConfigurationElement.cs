namespace Loom.Esb.Configuration
{
    using System.Configuration;

    public class ActorConfigurationElement : ConfigurationElement
    {
        public ActorConfigurationElement()
        {
        }

        public ActorConfigurationElement(string name)
        {
            Name = name;
        }

        private const string SubscriptionsElementName = "subscriptions";
        private const string NamePropertyName = "name";

        [ConfigurationProperty(NamePropertyName)]
        public string Name
        {
            get { return base[NamePropertyName] as string; }
            set { base[NamePropertyName] = value; }
        }

        [ConfigurationProperty("subscriptions")]
        [ConfigurationCollection(typeof(SubscriptionConfigurationElement), AddItemName = "subscription")]
        public SubscriptionConfigurationElementCollection Subscriptions
        {
            get { return base[SubscriptionsElementName] as SubscriptionConfigurationElementCollection; }
            set { base[SubscriptionsElementName] = value; }
        }
        
        [ConfigurationProperty("publications")]
        [ConfigurationCollection(typeof(PublicationConfigurationElement), AddItemName = "publication")]
        public PublicationConfigurationElementCollection Publications
        {
            get { return base["publications"] as PublicationConfigurationElementCollection; }
            set { base["publications"] = value; }
        }
    }
}