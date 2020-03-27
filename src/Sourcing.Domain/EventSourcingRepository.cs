using System;

namespace Sourcing.Domain
{
    internal class EventSourcingRepository<TAggregate, TEvent> : IRepository<TAggregate> 
        where TAggregate : AggregateRoot<TEvent>, new() //shortcut you can do as you see fit with new()
    {
        private readonly IEventStore<TEvent> storage;

        public EventSourcingRepository(IEventStore<TEvent> storage) => this.storage = storage;

        public void Save(TAggregate aggregate, int expectedVersion) => 
            this.storage.SaveEvents(aggregate.Id, aggregate.Changes, expectedVersion);

        public TAggregate GetById(Guid id)
        {
            var obj = new TAggregate();//lots of ways to do this
            var e = this.storage.GetEventsForAggregate(id);
            obj.LoadsFromHistory(e);
            return obj;
        }
    }
}
