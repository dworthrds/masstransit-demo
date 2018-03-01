using System;
using Contract;

namespace OrderService
{
    public class OrderCreated : IOrderCreated
    {
        public Guid CorrelationId { get; set; }
        public IOrder Order { get; set; }
        public DateTime When { get; set; }
    }
}