using System;
using MassTransit;

namespace Contract
{
    public interface IOrderCreated : CorrelatedBy<Guid>
    {
        IOrder Order { get; }
        DateTime When { get; }
    }
}