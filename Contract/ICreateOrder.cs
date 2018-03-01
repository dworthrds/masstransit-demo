using System;
using MassTransit;

namespace Contract
{
    public interface ICreateOrder : CorrelatedBy<Guid>
    {
        IOrder Order { get; }
        DateTime When { get; }
    }
}