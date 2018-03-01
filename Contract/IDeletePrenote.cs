using System;
using MassTransit;

namespace Contract
{
    public interface IDeletePrenote : CorrelatedBy<Guid>
    {
        IPrenote Prenote { get; }
        DateTime When { get; }
    }
}