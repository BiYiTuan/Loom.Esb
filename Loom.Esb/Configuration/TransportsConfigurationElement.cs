namespace Loom.Esb.Configuration
{
    using System.Configuration;

    public class TransportsConfigurationElement : ConfigurationElement
    {
        [ConfigurationProperty("default", IsRequired = false)]
        public string Default
        {
            get { return base["default"] as string; }
            set { base["default"] = value; }
        }

        [ConfigurationProperty("msmq", IsRequired = false)]
        public MsmqTransportConfigurationElement Msmq
        {
            get { return base["msmq"] as MsmqTransportConfigurationElement; }
        }
    }
}