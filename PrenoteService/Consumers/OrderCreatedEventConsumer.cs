using System;
using System.Threading.Tasks;
using Contract.Events;
using MassTransit;
using PrenoteService.Events;

namespace PrenoteService.Consumers
{
    public class OrderCreatedEventConsumer : IConsumer<IOrderCreatedEvent>
    {
        private readonly PrenoteRepository _prenoteRepository;

        public OrderCreatedEventConsumer(PrenoteRepository prenoteRepository)
        {
            _prenoteRepository = prenoteRepository;
        }

        public Task Consume(ConsumeContext<IOrderCreatedEvent> context)
        {
            var createdOrder = context.Message.Order;
            Console.WriteLine($"Received OrderCreated: {createdOrder.OrderNumber}");

            var prenote = _prenoteRepository.DeletePrenote(createdOrder.PrenoteFileNumber);

            var prenoteDeleted = new PrenoteDeletedEvent()
            {
                Prenote = prenote,
                CorrelationId = context.Message.CorrelationId
            };
            return context.Publish(prenoteDeleted);
        }
    }
}