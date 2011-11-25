namespace Loom.Esb
{
    using System.Linq;

    public class ActorFactory
    {
        private readonly Configuration.LoomEsbConfigurationSection _configurationSection;

        public ActorFactory(Configuration.LoomEsbConfigurationSection configurationSection)
        {
            _configurationSection = configurationSection;
        }

        public Actor CreateActor(string actorName)
        {
            var configuration = _configurationSection.Actors[actorName];
            if (configuration == null)
            { 
                throw new NoActorConfigurationException();
            }

            var transportConfiguration = new MsmqTransportConfiguration
                                             {
                                                 ConventionBasedNaming = _configurationSection.Transports.Msmq.ConventionBasedNaming,
                                                 Delivery = _configurationSection.Transports.Msmq.Delivery,
                                                 DefaultServer = _configurationSection.Transports.Msmq.DefaultServer
                                             };
            
            var actor = new Actor(actorName);

            var transport = new MsmqPublicationTransport();

            actor.Publications.AddRange(
                configuration.Publications.Select(conf => new Publication(conf.Topic, transport)));
            actor.Subscriptions.AddRange(
                configuration.Subscriptions.Select(conf => new Subscription(conf.Topic)));

            return actor;
        }
    }
}