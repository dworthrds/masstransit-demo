using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Contract;
using MassTransit;

namespace PrenoteService
{
    public class OrderCreatedConsumer : IConsumer<IOrderCreated>
    {
        private readonly PrenoteRepository _prenoteRepository;

        public OrderCreatedConsumer(PrenoteRepository prenoteRepository)
        {
            _prenoteRepository = prenoteRepository;
        }

        public Task Consume(ConsumeContext<IOrderCreated> context)
        {
            var createdOrder = context.Message.Order;
            Console.WriteLine($"Received OrderCreated: {createdOrder.OrderNumber}");

            var prenote = _prenoteRepository.DeletePrenote(createdOrder.PrenoteFileNumber);

            var prenoteDeleted = new PrenoteDeleted()
            {
                Prenote = prenote,
                CorrelationId = context.Message.CorrelationId
            };
            return context.Publish(prenoteDeleted);
        }
    }
}