using System;
using Contract.Model;
using MassTransit;

namespace Contract.Messages
{
    public interface ICreateOrderMessage : CorrelatedBy<Guid>
    {
        IOrder Order { get; }
        DateTime When { get; }
    }
}