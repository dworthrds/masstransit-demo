using System;
using MassTransit;

namespace Contract
{
    public interface IPrenoteDeleted : CorrelatedBy<Guid>
    {
        IPrenote Prenote { get; }
        DateTime When { get; }
    }
}