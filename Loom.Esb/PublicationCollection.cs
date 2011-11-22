namespace Loom.Esb
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class PublicationCollection : Collection<Publication>
    {
        public void AddRange(IEnumerable<Publication> range)
        {
            if (range == null) throw new ArgumentNullException("range");

            foreach (var element in range)
            {
                Add(element);
            }
        }
    }
}