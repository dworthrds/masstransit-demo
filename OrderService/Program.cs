using System;
using Autofac;
using Configuration;
using MassTransit;
using MassTransit.Log4NetIntegration.Logging;

namespace OrderService
{
    class Program
    {
        static void Main(string[] args)
        {
            Log4NetLogger.Use();
            var builder = new ContainerBuilder();

            builder.RegisterType<CreateOrderConsumer>().AsSelf();
            builder.Register(c => new OrderRepository());
            builder.Register(context =>
            {
                var busControl = BusInitializer.CreateBus(x =>
                {
                    x.ReceiveEndpoint("CreateOrder", e =>
                    {
                        e.LoadFrom(context);
                    });
                });

                return busControl;
            }).SingleInstance().As<IBusControl>().As<IBus>();

            var container = builder.Build();

            var bus = container.Resolve<IBusControl>();
            bus.Start();

            Console.WriteLine("Waiting...");
            Console.ReadKey();

            bus.Stop();
        }
    }
}
