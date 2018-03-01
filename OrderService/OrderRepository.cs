﻿using System;
using System.Threading;
using Contract;

namespace OrderService
{
    public class OrderRepository
    {
        public IOrder CreateNewOrder(IOrder order)
        {
            Console.WriteLine("Creating Order...");
            Thread.Sleep(1000);

            return order;
        }
    }
}