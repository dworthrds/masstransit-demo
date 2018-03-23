using System;
using Contract.Events;
using Contract.Model;

namespace OrderService.Events
{
    public class OrderCreatedEvent : IOrderCreatedEvent
    {
        public Guid CorrelationId { get; set; }
        public IOrder Order { get; set; }
        public DateTime When { get; set; }
    }
}