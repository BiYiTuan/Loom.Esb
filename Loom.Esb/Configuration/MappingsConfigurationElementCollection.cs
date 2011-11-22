namespace Loom.Esb.Configuration
{
    using System.Configuration;

    public class MappingsConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MappingConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MappingConfigurationElement)element).Topic;
        }
    }
}