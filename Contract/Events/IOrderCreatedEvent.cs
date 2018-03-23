using System;
using Contract.Model;
using MassTransit;

namespace Contract.Events
{
    public interface IOrderCreatedEvent : CorrelatedBy<Guid>
    {
        IOrder Order { get; }
        DateTime When { get; }
    }
}