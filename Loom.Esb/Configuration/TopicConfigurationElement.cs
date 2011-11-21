namespace Loom.Esb.Configuration
{
    using System.Configuration;

    public class TopicConfigurationElement : ConfigurationElement
    {
        public TopicConfigurationElement()
        {
        }

        public TopicConfigurationElement(string name)
        {
            Name = name;
        }

        private const string NamePropertyName = "name";

        [ConfigurationProperty(NamePropertyName, IsKey = true)]
        public string Name
        {
            get { return base[NamePropertyName] as string; }
            set { base[NamePropertyName] = value; }
        }
    }
}