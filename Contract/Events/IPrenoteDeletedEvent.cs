using System;
using MassTransit;

namespace Contract.Events
{
    public interface IPrenoteDeletedEvent : CorrelatedBy<Guid>
    {
        string PrenoteJson { get; }
        DateTime When { get; }
    }
}