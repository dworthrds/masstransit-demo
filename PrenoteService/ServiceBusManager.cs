using System.Reflection;
using Autofac;
using Configuration;
using MassTransit;
using MassTransit.Log4NetIntegration.Logging;

namespace PrenoteService
{
    public class ServiceBusManager
    {
        private readonly IBusControl _busControl;

        private static ServiceBusManager _instance;
        public static ServiceBusManager Instance => _instance ?? (_instance = new ServiceBusManager());
        private ServiceBusManager()
        {
            Log4NetLogger.Use();
            var builder = new ContainerBuilder();

            builder.RegisterConsumers(Assembly.GetExecutingAssembly());
            builder.Register(c => new PrenoteRepository());
            builder.Register(context =>
            {
                var busControl = BusInitializer.CreateBus(x =>
                {
                    x.ReceiveEndpoint("PrenoteServiceMessageProcessor", e =>
                    {
                        e.LoadFrom(context);
                    });
                });

                return busControl;
            }).SingleInstance().As<IBusControl>().As<IBus>();

            var container = builder.Build();

            _busControl = container.Resolve<IBusControl>();
        }

        public void StartBus()
        {
            _busControl.Start();
        }

        public void StopBus()
        {
            _busControl.Stop();
        }
    }
}