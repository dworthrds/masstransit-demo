using System;
using Contract.Model;
using MassTransit;

namespace Contract.Events
{
    public interface IPrenoteDeletedEvent : CorrelatedBy<Guid>
    {
        IPrenote Prenote { get; }
        DateTime When { get; }
    }
}