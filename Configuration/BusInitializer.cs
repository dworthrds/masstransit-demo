using System;
using MassTransit;
using MassTransit.RabbitMqTransport;

namespace Configuration
{
    public class BusInitializer
    {
        public static IBusControl CreateBus(Action<IRabbitMqBusFactoryConfigurator> moreInitialization = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(GetUri(), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });
                moreInitialization?.Invoke(cfg);
            });
        }

        public static Uri GetUri()
        {
            return new Uri("rabbitmq://localhost/");
        }
    }
}