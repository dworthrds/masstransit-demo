using System;
using Contract.Events;

namespace PrenoteService.Events
{
    public class PrenoteDeletedEvent : IPrenoteDeletedEvent
    {
        public Guid CorrelationId { get; set; }
        public string PrenoteJson { get; set; }
        public DateTime When { get; set; }
    }
}