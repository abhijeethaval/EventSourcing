using System;
using System.Collections.Generic;

namespace Sourcing.Domain
{
    internal abstract class AggregateRoot<TEvent>
    {
        public Guid Id { get; set; }
        private readonly List<TEvent> changes = new List<TEvent>();

        protected AggregateRoot() { }

        internal IEnumerable<TEvent> Changes => this.changes;

        protected void Raise(TEvent @event)
        {
            this.changes.Add(@event);
            Apply(@event);
        }

        internal void LoadsFromHistory(IEnumerable<TEvent> e)
        {
            foreach (var @event in e)
            {
                Apply(@event);
            }
        }

        protected abstract void Apply(TEvent @event);
    }
}