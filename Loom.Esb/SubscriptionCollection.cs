namespace Loom.Esb
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class SubscriptionCollection : Collection<Subscription>
    {
        public void AddRange(IEnumerable<Subscription> range)
        {
            if (range == null) throw new ArgumentNullException("range");

            foreach(var element in range)
            {
                Add(element);
            }
        }
    }
}