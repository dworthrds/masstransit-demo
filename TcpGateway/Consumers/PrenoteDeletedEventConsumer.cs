using System;
using System.Threading.Tasks;
using Contract.Events;
using MassTransit;

namespace TcpGateway.Consumers
{
    public class PrenoteDeletedEventConsumer : IConsumer<IPrenoteDeletedEvent>
    {
        public Task Consume(ConsumeContext<IPrenoteDeletedEvent> context)
        {
            Console.WriteLine($"Notifying UI that Prenote {context.Message.PrenoteJson} has been deleted.");
            return Task.CompletedTask;
        }
    }
}