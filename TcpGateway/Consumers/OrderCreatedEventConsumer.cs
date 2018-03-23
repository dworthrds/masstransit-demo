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
            Console.WriteLine($"Notifying UI that Order {context.Message.Order.OrderNumber} has been created.");
            return Task.CompletedTask;
        }
    }
}