namespace Loom.Esb.Configuration
{
    using System.Configuration;

    public class LoomEsbConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("actors")]
        [ConfigurationCollection(typeof(ActorConfigurationElement), AddItemName = "actor")]
        public ActorsConfigurationElementCollection Actors
        {
            get { return base["actors"] as ActorsConfigurationElementCollection; }
            set { base["actors"] = value; }
        }

        [ConfigurationProperty("topics")]
        [ConfigurationCollection(typeof(TopicConfigurationElement), AddItemName = "topic")]
        public TopicsConfigurationElementCollection Topics
        {
            get { return base["topics"] as TopicsConfigurationElementCollection; }
            set { base["topics"] = value; }
        }
    }
}