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
            ServiceBusManager.Instance.StartBus();

            Console.WriteLine("Waiting...");
            Console.ReadKey();

            ServiceBusManager.Instance.StopBus();
        }
    }
}
