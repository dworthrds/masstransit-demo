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
            var createdOrder = context.Message.OrderJson;
            Console.WriteLine($"Received OrderCreated: {createdOrder}");

            var prenote = _prenoteRepository.DeletePrenote(54);

            var prenoteDeleted = new PrenoteDeletedEvent()
            {
                PrenoteJson = prenote,
                CorrelationId = context.Message.CorrelationId
            };
            return context.Publish(prenoteDeleted);
        }
    }
}