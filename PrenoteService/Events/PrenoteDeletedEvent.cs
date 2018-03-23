using System;
using Contract.Events;
using Contract.Model;

namespace PrenoteService.Events
{
    public class PrenoteDeletedEvent : IPrenoteDeletedEvent
    {
        public Guid CorrelationId { get; set; }
        public IPrenote Prenote { get; set; }
        public DateTime When { get; set; }
    }
}