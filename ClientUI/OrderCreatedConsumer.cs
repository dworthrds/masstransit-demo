using System;
using System.Threading;
using System.Threading.Tasks;
using Contract;
using MassTransit;

namespace ClientUI
{
    public class OrderCreatedConsumer : IConsumer<IOrderCreated>
    {
        public Task Consume(ConsumeContext<IOrderCreated> context)
        {
            Console.WriteLine($"Notifying UI that Order {context.Message.Order.OrderNumber} has been created.");
            return Task.CompletedTask;
        }
    }
}