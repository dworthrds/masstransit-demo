using System;
using System.Threading.Tasks;
using Contract.Events;
using MassTransit;

namespace TcpGateway.Consumers
{
    public class OrderCreatedEventConsumer : IConsumer<IOrderCreatedEvent>
    {
        public Task Consume(ConsumeContext<IOrderCreatedEvent> context)
        {
            Console.WriteLine($"Notifying UI that Order {context.Message.OrderJson} has been created.");
            return Task.CompletedTask;
        }
    }
}