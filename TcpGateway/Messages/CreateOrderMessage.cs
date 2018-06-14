using System;
using Contract.Messages;

namespace TcpGateway.Messages
{
    public class CreateOrderMessage : ICreateOrderMessage
    {
        public Guid CorrelationId { get; set; }
        public string OrderJson { get; set; }
        public DateTime When { get; set; }
    }
}