using System;
using Contract.Model;
using MassTransit;

namespace Contract.Messages
{
    public interface IDeletePrenoteMessage : CorrelatedBy<Guid>
    {
        IPrenote Prenote { get; }
        DateTime When { get; }
    }
}