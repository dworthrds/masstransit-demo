using System;
using System.Threading.Tasks;
using Contract.Events;
using MassTransit;

namespace OrderService.Consumers
{
    public class PrenoteDeletedEventConsumer : IConsumer<IPrenoteDeletedEvent>
    {
        public Task Consume(ConsumeContext<IPrenoteDeletedEvent> context)
        {
            Console.WriteLine($"Notifying OrderService that Prenote {context.Message.PrenoteJson} has been deleted.");
            return Task.CompletedTask;
        }
    }
}