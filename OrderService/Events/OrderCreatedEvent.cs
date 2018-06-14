using System;
using Contract.Events;

namespace OrderService.Events
{
    public class OrderCreatedEvent : IOrderCreatedEvent
    {
        public Guid CorrelationId { get; set; }
        public string OrderJson { get; set; }
        public DateTime When { get; set; }
    }
}