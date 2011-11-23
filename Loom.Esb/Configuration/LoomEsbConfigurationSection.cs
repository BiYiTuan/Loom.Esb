namespace Loom.Esb.Configuration
{
    using System.Configuration;

    public class LoomEsbConfigurationSection : ConfigurationSection
    {
        public const string SectionName = "loom.esb";

        [ConfigurationProperty("xmlns", IsRequired = false)]
        public string Xmlns
        {
            get { return (string)base["xmlns"]; }
        }

        [ConfigurationProperty("transports")]
        public TransportsConfigurationElement Transports
        {
            get { return base["transports"] as TransportsConfigurationElement; }
        }

        [ConfigurationProperty("actors")]
        [ConfigurationCollection(typeof(ActorConfigurationElement), AddItemName = "actor")]
        public ActorsConfigurationElementCollection Actors
        {
            get { return base["actors"] as ActorsConfigurationElementCollection; }
            //set { base["actors"] = value; }
        }

        [ConfigurationProperty("topics")]
        [ConfigurationCollection(typeof(TopicConfigurationElement), AddItemName = "topic")]
        public TopicsConfigurationElementCollection Topics
        {
            get { return base["topics"] as TopicsConfigurationElementCollection; }
            //set { base["topics"] = value; }
        }
    }
}