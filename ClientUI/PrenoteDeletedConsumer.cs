using System;
using System.Threading.Tasks;
using Contract;
using MassTransit;

namespace ClientUI
{
    public class PrenoteDeletedConsumer : IConsumer<IPrenoteDeleted>
    {
        public Task Consume(ConsumeContext<IPrenoteDeleted> context)
        {
            Console.WriteLine($"Notifying UI that Prenote {context.Message.Prenote.FileNumber} has been deleted.");
            return Task.CompletedTask;
        }
    }
}