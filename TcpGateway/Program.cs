using System;
using Contract.Messages;
using TcpGateway.Messages;

namespace TcpGateway
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceBusManager.Instance.StartBus();

            RunLoop();

            ServiceBusManager.Instance.StopBus();
        }

        static void RunLoop()
        {
            while (true)
            {
                Console.WriteLine("Press 'O' to create an order, or 'Q' to quit.");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.O:
                        
                        var createOrder = new CreateOrderMessage()
                        {
                            CorrelationId = Guid.NewGuid(),
                            OrderJson = "OrderNumber:2354",
                            When = DateTime.Now
                        };

                        Console.WriteLine($"Sending CreateOrder command, OrderNumber = {createOrder.OrderJson}");
                        ServiceBusManager.Instance.BusControl.Publish<ICreateOrderMessage>(createOrder);
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
