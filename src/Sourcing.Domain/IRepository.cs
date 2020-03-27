using System;

namespace Sourcing.Domain
{
    internal interface IRepository<TAggregate> where TAggregate : new()
    {
        void Save(TAggregate aggregate, int expectedVersion);
        TAggregate GetById(Guid id);
    }
}
