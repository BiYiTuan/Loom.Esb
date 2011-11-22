namespace Loom.Esb.Configuration
{
    using System.Configuration;

    public class ActorsConfigurationElementCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ActorConfigurationElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ActorConfigurationElement) element).Name;
        }

        public void Add(ActorConfigurationElement actor)
        {
            BaseAdd(actor);
        }

        public new ActorConfigurationElement this[string name]
        {
            get { return BaseGet(name) as ActorConfigurationElement; }
        }
    }
}