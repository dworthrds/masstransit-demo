using System;
using Contract;

namespace ClientUI
{
    public class CreateOrder : ICreateOrder
    {
        public Guid CorrelationId { get; set; }
        public IOrder Order { get; set; }
        public DateTime When { get; set; }
    }
}