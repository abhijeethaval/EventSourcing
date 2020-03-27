using System;
using System.Collections.Generic;

namespace Sourcing.Domain
{
    internal interface IEventStore<T> 
    {
        void SaveEvents(Guid aggregateId, IEnumerable<T> events, int expectedVersion);

        IEnumerable<T> GetEventsForAggregate(Guid id);
    }
}