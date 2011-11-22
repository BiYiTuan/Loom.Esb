namespace Loom.Esb.Configuration
{
    using System.Configuration;

    public class MappingConfigurationElement : ConfigurationElement
    {
        public string Topic
        {
            get { return base["topic"] as string; }
            set { base["topic"] = value; }
        }
    }
}