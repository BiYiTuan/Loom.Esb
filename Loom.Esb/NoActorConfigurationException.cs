namespace Loom.Esb
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    public class NoActorConfigurationException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public NoActorConfigurationException()
        {
        }

        public NoActorConfigurationException(string message)
            : base(message)
        {
        }

        public NoActorConfigurationException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected NoActorConfigurationException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }
    }
}