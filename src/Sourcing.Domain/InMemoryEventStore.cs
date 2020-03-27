using System;
using System.Collections.Generic;
using System.Linq;

namespace Sourcing.Domain
{
    internal class InMemoryEventStore<T> : IEventStore<T>
    {
        private static readonly Dictionary<Guid, List<T>> _events = new Dictionary<Guid, List<T>>();
        public IEnumerable<T> GetEventsForAggregate(Guid aggregateId) =>
            _events.ContainsKey(aggregateId) 
            ? _events[aggregateId] 
            : Enumerable.Empty<T>();

        public void SaveEvents(Guid aggregateId, IEnumerable<T> events, int expectedVersion)
        {
            _ = events ?? throw new ArgumentNullException(nameof(events));
            if (!_events.ContainsKey(aggregateId))
            {
                _events.Add(aggregateId, new List<T>());
            }

            foreach (var @event in events)
            {
                _events[aggregateId].Add(@event);
            }
        }
    }
}