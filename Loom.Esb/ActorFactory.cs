namespace Loom.Esb
{
    using System.Linq;
    using Configuration;

    public class ActorFactory
    {
        private readonly LoomEsbConfigurationSection _configurationSection;

        public ActorFactory(Configuration.LoomEsbConfigurationSection configurationSection)
        {
            _configurationSection = configurationSection;
        }

        public Actor CreateActor(string actorName)
        {
            var configuration = _configurationSection.Actors[actorName];
            if (configuration == null)
                throw new NoActorConfigurationException();

            var actor = new Actor(actorName);
            actor.Publications.AddRange(
                configuration.Publications.Select(conf => new Publication(conf.Topic)));
            actor.Subscriptions.AddRange(
                configuration.Subscriptions.Select(conf => new Subscription(conf.Topic)));

            return actor;
        }
    }
}