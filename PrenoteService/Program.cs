using System;
using Autofac;
using Configuration;
using MassTransit;
using MassTransit.Log4NetIntegration.Logging;

namespace PrenoteService
{
    class Program
    {
        static void Main(string[] args)
        {
            Log4NetLogger.Use();
            var builder = new ContainerBuilder();

            builder.RegisterType<OrderCreatedConsumer>().AsSelf();
            builder.Register(c => new PrenoteRepository());
            builder.Register(context =>
                {
                    var busControl = BusInitializer.CreateBus(cfg =>
                    {
                        cfg.ReceiveEndpoint("OrderCreated_PrenoteService", ec =>
                        {
                            ec.LoadFrom(context);
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
