using System;
using MassTransit;

namespace Contract.Messages
{
    public interface ICreateOrderMessage : CorrelatedBy<Guid>
    {
        string OrderJson { get; }
        DateTime When { get; }
    }
}