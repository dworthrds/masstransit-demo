using System;
using Configuration;
using Contract;
using MassTransit;
using MassTransit.Log4NetIntegration.Logging;

namespace ClientUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Log4NetLogger.Use();
            var bus = BusInitializer.CreateBus(cfg =>
            {
                cfg.ReceiveEndpoint("OrderCreated_Client", e =>
                {
                    e.Consumer<OrderCreatedConsumer>();
                });

                cfg.ReceiveEndpoint("PrenoteDeleted_Client", e =>
                {
                    e.Consumer<PrenoteDeletedConsumer>();
                });
            });
            bus.Start();

            RunLoop(bus);

            bus.Stop();
        }

        static void RunLoop(IBusControl bus)
        {
            while (true)
            {
                Console.WriteLine("Press 'O' to create an order, or 'Q' to quit.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.O:
                        var order = new Order
                        {
                            OrderNumber = 123456,
                            PrenoteFileNumber = 789789
                        };

                        var createOrder = new CreateOrder()
                        {
                            CorrelationId = Guid.NewGuid(),
                            Order = order,
                            When = DateTime.Now
                        };

                        Console.WriteLine($"Sending CreateOrder command, OrderNumber = {order.OrderNumber}");
                        bus.Publish<ICreateOrder>(createOrder);
                        break;

                    case ConsoleKey.Q:
                        return;

                    default:
                        Console.WriteLine("Unknown input. Please try again.");
                        break;

                }
            }
        }
    }
}
