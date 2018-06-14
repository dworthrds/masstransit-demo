using System;
using System.Threading;

namespace OrderService
{
    public class OrderRepository
    {
        public string CreateNewOrder(string order)
        {
            Console.WriteLine("Creating Order...");
            Thread.Sleep(1000);

            return order;
        }
    }
}