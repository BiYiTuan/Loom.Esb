namespace Loom.Esb
{
    using System.Linq;

    public class ActorFactory
    {
        private readonly Configuration.LoomEsbConfigurationSection _configurationSection;
        private readonly ITransport _transport;

        public ActorFactory(Configuration.LoomEsbConfigurationSection configurationSection)
        {
            _configurationSection = configurationSection;
            _transport = new MsmqTransport();
        }

        public Actor CreateActor(string actorName)
        {
            var configuration = _configurationSection.Actors[actorName];
            if (configuration == null)
                throw new NoActorConfigurationException();

            var actor = new Actor(actorName, _transport);
            actor.Publications.AddRange(
                configuration.Publications.Select(conf => new Publication(conf.Topic)));
            actor.Subscriptions.AddRange(
                configuration.Subscriptions.Select(conf => new Subscription(conf.Topic)));

            return actor;
        }
    }
}