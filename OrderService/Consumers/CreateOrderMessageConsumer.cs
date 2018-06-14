using System;
using System.Threading.Tasks;
using Contract.Messages;
using MassTransit;
using OrderService.Events;

namespace OrderService.Consumers
{
    public class CreateOrderMessageConsumer : IConsumer<ICreateOrderMessage>
    {
        private readonly OrderRepository _orderRepository;

        public CreateOrderMessageConsumer(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task Consume(ConsumeContext<ICreateOrderMessage> context)
        {
            var order = context.Message.OrderJson;

            Console.WriteLine($"Received CreateOrder: {order}");

            var newOrder = _orderRepository.CreateNewOrder(order);

            var orderCreated = new OrderCreatedEvent()
            {
                CorrelationId = context.Message.CorrelationId,
                OrderJson = newOrder,
                When = DateTime.Now
            };
            return context.Publish(orderCreated);
        }
    }
}