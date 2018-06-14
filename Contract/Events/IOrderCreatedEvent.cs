using System;
using MassTransit;

namespace Contract.Events
{
    public interface IOrderCreatedEvent : CorrelatedBy<Guid>
    {
        string OrderJson { get; }
        DateTime When { get; }
    }
}