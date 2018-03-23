using System.Reflection;
using Autofac;
using Configuration;
using MassTransit;
using MassTransit.Log4NetIntegration.Logging;

namespace TcpGateway
{
    public class ServiceBusManager
    {
        public IBusControl BusControl { get; }

        private static ServiceBusManager _instance;
        public static ServiceBusManager Instance => _instance ?? (_instance = new ServiceBusManager());
        private ServiceBusManager()
        {
            Log4NetLogger.Use();
            var builder = new ContainerBuilder();

            builder.RegisterConsumers(Assembly.GetExecutingAssembly());
            builder.Register(context =>
            {
                var busControl = BusInitializer.CreateBus(x =>
                {
                    x.ReceiveEndpoint("ClientEventProcessor", e =>
                    {
                        e.LoadFrom(context);
                    });
                });

                return busControl;
            }).SingleInstance().As<IBusControl>().As<IBus>();

            var container = builder.Build();

            BusControl = container.Resolve<IBusControl>();
        }

        public void StartBus()
        {
            BusControl.Start();
        }

        public void StopBus()
        {
            BusControl.Stop();
        }
    }
}