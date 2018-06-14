using System;
using System.Threading.Tasks;
using Contract.Messages;
using MassTransit;

namespace TcpGateway.Consumers
{
    public class CreateOrderMessageConsumer : IConsumer<ICreateOrderMessage>
    {
        public Task Consume(ConsumeContext<ICreateOrderMessage> context)
        {
            var order = context.Message.OrderJson;

            Console.WriteLine($"Received CreateOrder: {order}");

            return Task.CompletedTask;
        }
    }
}