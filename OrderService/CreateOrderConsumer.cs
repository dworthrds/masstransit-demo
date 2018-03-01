using System;
using System.Threading;
using System.Threading.Tasks;
using Contract;
using MassTransit;

namespace OrderService
{
    public class CreateOrderConsumer : IConsumer<ICreateOrder>
    {
        private readonly OrderRepository _orderRepository;

        public CreateOrderConsumer(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task Consume(ConsumeContext<ICreateOrder> context)
        {
            var order = context.Message.Order;

            Console.WriteLine($"Received CreateOrder: {order.OrderNumber}");

            var newOrder = _orderRepository.CreateNewOrder(order);

            var orderCreated = new OrderCreated()
            {
                CorrelationId = context.Message.CorrelationId,
                Order = newOrder,
                When = DateTime.Now
            };
            return context.Publish(orderCreated);
        }
    }
}