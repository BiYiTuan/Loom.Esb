namespace Loom.Esb.Configuration
{
    using System.Configuration;

    public class MsmqTransportConfigurationElement : ConfigurationElement
    {
        protected override void InitializeDefault()
        {
            ConventionBasedMapping = true;
            DefaultServer = "localhost";
            Delivery = DeliveryMethod.Direct;
            base.InitializeDefault();
        }

        [ConfigurationProperty("conventionBasedNaming", IsRequired = false)]
        public bool ConventionBasedMapping
        {
            get { return (bool)base["conventionBasedNaming"]; }
            set { base["conventionBasedNaming"] = value; }
        }

        [ConfigurationProperty("defaultServer", IsRequired = false)]
        public string DefaultServer
        {
            get { return base["defaultServer"] as string; }
            set { base["defaultServer"] = value; }
        }

        [ConfigurationProperty("delivery", IsRequired = false)]
        public DeliveryMethod Delivery
        {
            get { return (DeliveryMethod)base["delivery"]; }
            set { base["delivery"] = value; }
        }

        [ConfigurationProperty("mappings")]
        [ConfigurationCollection(typeof(MappingConfigurationElement))]
        public MappingsConfigurationElementCollection Mappings
        {
            get { return base["mappings"] as MappingsConfigurationElementCollection; }
        }
    }
}