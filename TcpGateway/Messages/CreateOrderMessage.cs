using System;
using Contract.Messages;
using Contract.Model;

namespace TcpGateway.Messages
{
    public class CreateOrderMessage : ICreateOrderMessage
    {
        public Guid CorrelationId { get; set; }
        public IOrder Order { get; set; }
        public DateTime When { get; set; }
    }
}