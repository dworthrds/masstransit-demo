using System;
using System.Reflection;
using Autofac;

namespace OrderService
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
